using Microsoft.AspNetCore.Mvc;
using DataWebApplication.Data;
using DataWebApplication.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;


namespace DataWebApplication.Controllers
{
    public class LanguagePersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguagePersonController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(int languageId)
        {
            PersonLanguageViewModel PLVM = new PersonLanguageViewModel();

            var language = _context.Languages
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Person)
                .SingleOrDefault(x => x.LanguageId == languageId);
            PLVM.Language = language;

            return View(PLVM);
        }
    }
}
