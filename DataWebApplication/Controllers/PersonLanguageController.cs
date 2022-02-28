using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataWebApplication.Data;
using DataWebApplication.Models.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DataWebApplication.Models.Entities;
using System;

namespace DataWebApplication.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonLanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            PersonLanguageViewModel PLVM = new PersonLanguageViewModel();

            
            var person = _context.People
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Language)
                .SingleOrDefault(x => x.PersonId == (int)TempData["id"]);

            ViewBag.Id = TempData["id"];
            ViewBag.Name = person.Name;
            PLVM.Person = person;
            
            return View(PLVM);
        }

        [HttpPost]
        public IActionResult PersonRedirect(int personId)
        {
            TempData["id"] = personId;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddLanguage(PersonLanguageViewModel PLVM, string id)
        {
            string newLanguage = PLVM.Language.Name;
            int personId = Convert.ToInt32(id);
            Language language;

            var person = _context.People
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Language)
                .SingleOrDefault(p => p.PersonId == personId);

            int languagesCount = _context.Languages.Count();
            
            if (!_context.Languages.Any(p => p.Name == newLanguage))
            {
                language = new Language { Name = newLanguage };
            }
            else
            {
                language = _context.Languages.FirstOrDefault(x => x.Name == newLanguage);
            }
            

            PersonLanguage personLanguage = new PersonLanguage { Person = person, Language = language };
            _context.PersonLanguages.Add(personLanguage);
            _context.SaveChanges();

            
            var newPerson = _context.People
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Language)
                .SingleOrDefault(x => x.PersonId == personId);

            ViewBag.Id = id;
            PLVM.Person = newPerson;
            return View("Index", PLVM);
        }

        [HttpPost]
      
        public ActionResult Delete(int personId, int languageId)
        {
          
            var person = _context.People.SingleOrDefault(p => p.PersonId == personId);
            var language = _context.Languages.SingleOrDefault(p => p.LanguageId == languageId);
            var personLanguage = new PersonLanguage { Person = person, LanguageId = languageId };


            _context.PersonLanguages.Remove(personLanguage);            
            _context.SaveChanges();

            PersonLanguageViewModel PLVM = new PersonLanguageViewModel();

            var newPerson = _context.People
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Language)
                .SingleOrDefault(x => x.PersonId == personId);

            ViewBag.Id = TempData["id"];
            PLVM.Person = person;

            return View("Index", PLVM);
        }
    }
}
