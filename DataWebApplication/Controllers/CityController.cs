using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DataWebApplication.Data;
using DataWebApplication.Models.Entities;
using DataWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DataWebApplication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CityViewModel CV = new CityViewModel
            {
                Cities = _context.Cities.ToList()
            };
            return View(CV);
        }

        [HttpPost]
        public IActionResult Index(CityViewModel CCV)
        {
            CityViewModel CV = new CityViewModel();

            if (ModelState.IsValid)
            {
                City city = new City()
                {
                    Name = CCV.CreateCityVM.Name
                };
                _context.Cities.Add(city);
                _context.SaveChanges();
                CV.Cities = _context.Cities.ToList();
                return RedirectToAction(nameof(Index));
            }
            CCV.Cities = _context.Cities.ToList();
            return View(CCV);
        }

        [HttpPost]
        public ActionResult Delete(string city)
        {
            var cityToDelete = _context.Cities.FirstOrDefault(
                x => x.Name == city);
            _context.Cities.Remove(cityToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
