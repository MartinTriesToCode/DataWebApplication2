using DataWebApplication.Data;
using DataWebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;



namespace DataWebApplication.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LanguageViewModel LV = new LanguageViewModel
            {
                Languages = _context.Languages.ToList()
            };
            return View(LV);
        }

    }
}
