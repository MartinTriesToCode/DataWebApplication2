using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DataWebApplication.Models.Entities;
using DataWebApplication.Models.ViewModels;
using DataWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DataWebApplication.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
   
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Person(string sortOrder)
        {
            List<Person> listCopy = new List<Person>();
            IEnumerable<Person> newList = new List<Person>();

            PersonViewModel model = new PersonViewModel();
          
            ViewBag.Name = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.City = sortOrder == "City" ? "City_desc" : "City";
            ViewBag.Country = sortOrder == "Country" ? "Country_desc" : "Country";
            listCopy = _context.People.Include("City").Include("Country").ToList();

            newList = sortOrder switch
            {
                "Name_desc" => listCopy.OrderByDescending(person => person.Name),
                "City" => listCopy.OrderBy(person => person.City.Name),
                "City_desc" => listCopy.OrderByDescending(person => person.City.Name),
                "Country" => listCopy.OrderBy(person => person.Country.Name),
                "Country_desc" => listCopy.OrderByDescending(person => person.Country.Name),
                _ => listCopy.OrderBy(person => person.Name),
            };
            model.People = newList.ToList();
            
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public ActionResult Person(CreatePersonViewModel createViewModel)
        {
            string filtertext;
            List<Person> result;
            List<Person> db;
            ViewBag.filter = null;
            PersonViewModel pvm = new PersonViewModel();
            var model = createViewModel;
            pvm.CreateViewModel = model;
            db = _context.People.Include("City").Include("Country").ToList();
            pvm.People = db;
          
            if (!string.IsNullOrWhiteSpace(Request.Form["submit_search"]))
            {
                if (string.IsNullOrWhiteSpace(model.Name) &&
                string.IsNullOrWhiteSpace(model.City) &&
                string.IsNullOrWhiteSpace(model.Country))
                {
                    ViewBag.filter = "on";
                    return View(pvm);
                }
                else
                {
                    filtertext = model.Name + model.City + model.Country;
                    result = db.FindAll(x => filtertext.Contains(x.Name)
                        || filtertext.Contains(x.City.Name)
                        || filtertext.Contains(x.Country.Name));
                   
                    pvm.People = result;
                    ViewBag.filter = "on";
                    return View(pvm);
                }
            }

            if (ModelState.IsValid)
            {
                //Create country and add to database
                Country country = new Country { Name = createViewModel.Country };
                _context.Countries.Add(country);
                _context.SaveChanges();

                //Create city and add to database
                City city = new City { Name = createViewModel.City, CountryId = country.Id };
                _context.Cities.Add(city);
                _context.SaveChanges();

                Person person = new Person {
                    Name = createViewModel.Name,
                    Phone = createViewModel.Phone,
                    City = city,
                    Country = country
                };
                _context.People.Add(person);
                _context.SaveChanges();
            }

            pvm.People = _context.People.Include("City").Include("Country").ToList();
    
            return View(pvm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete()
        {
            return RedirectToAction("Person");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _context.People.Remove(_context.People.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Person");
        }

        //Partial view action
        [HttpGet]
        public ActionResult PersonList()
        {
            var list = _context.People.Include("City").Include("Country").ToList();
            return PartialView("_partialPerson", list);
        }

        //Partial view action
        [HttpGet]
        public ActionResult LanguageList(string Id)
        {
            int intId = Convert.ToInt32(Id);
            var person = _context.People
               .Include(p => p.PersonLanguages)
               .ThenInclude(p => p.Language)
               .SingleOrDefault(x => x.PersonId == intId);
            return PartialView("_partialLanguage", person);
        }

        //Partial view action
        [HttpPost]
        public ActionResult PersonLanguages(string id)
        {
            int intId = Convert.ToInt32(id);
            PersonLanguageViewModel LVM = new PersonLanguageViewModel();
            if (_context.People.Find(intId)==null)
                return Json(new
                {
                    msg = "Invalid Id " 
                });
            else
                return Json(new
                {
                    msg = ""
                });

        }

        //Partial view action
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult PersonDelete(string id)
        {
            int intId = Convert.ToInt32(id);
            var person = _context.People.Find(intId);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
                return Json(new
                {
                    msg = "Successfully removed person with id " + id
                });
            }
            else
                return Json(new
                {
                    msg = "Attempt to remove person with id " + id + " failed"
                });
        }
    }
}
