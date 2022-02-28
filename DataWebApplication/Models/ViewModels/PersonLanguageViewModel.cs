using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWebApplication.Models.Entities;

namespace DataWebApplication.Models.ViewModels
{
    public class PersonLanguageViewModel
    {
        public List<PersonLanguage> Speakers { get; set; }
        public List<Person> People { get; set; }
        public Person Person { get; set; }
        public Language Language { get; set; }
        public string PersonId { get; set; }
    }
}
