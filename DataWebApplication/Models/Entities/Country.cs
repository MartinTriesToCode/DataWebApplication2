
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataWebApplication.Models.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Person> CountryPeople { get; set; }
        public List<City> Cities { get; set; }

    }
}
