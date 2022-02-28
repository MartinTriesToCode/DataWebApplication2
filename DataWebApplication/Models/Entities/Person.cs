using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataWebApplication.Models.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

       
        public string Name { get; set; }
      
        public string Phone { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public IList<Language> Languages { get; set; }
        public IList<PersonLanguage> PersonLanguages { get; set; }

    }
}
