using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWebApplication.Data;
using DataWebApplication.Models.Entities;
using DataWebApplication.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CountryViewModel CV = new CountryViewModel
            {
                Countries = _context.Countries.ToList()
            };
            return View(CV);
        }

        [HttpPost]
        public IActionResult Index(CountryViewModel CCV)
        {
            CountryViewModel CV = new CountryViewModel();

            if (ModelState.IsValid)
            {
                Country country = new Country()
                {
                    Name = CCV.CreateCountryVM.Name
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
                CV.Countries = _context.Countries.ToList();
                return RedirectToAction(nameof(Index));
            }
            CCV.Countries = _context.Countries.ToList();
            return View(CCV);
        }

        [HttpPost]
        public ActionResult Delete(string country)
        {
            var countryToDelete = _context.Countries.FirstOrDefault(
                x => x.Name == country);
            _context.Countries.Remove(countryToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
