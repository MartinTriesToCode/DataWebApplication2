using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApplication.Models.Entities
{
    public class Language
    {
        
        [Key]
        public int LanguageId { get; set; }

       
        public string Name { get; set; }
        public IList<Person> Persons { get; set; }
        public IList<PersonLanguage> PersonLanguages { get; set; }

    }
}
