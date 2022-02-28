using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWebApplication.Models.Entities;
using DataWebApplication.Models.ViewModels;

namespace DataWebApplication.Models.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages { get; set; }

        public CreateLanguageViewModel CreateLVM { get; set; }
    }
}
