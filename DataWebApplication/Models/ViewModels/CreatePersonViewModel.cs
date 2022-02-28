using System.ComponentModel.DataAnnotations;
using DataWebApplication.Models.Entities;

namespace DataWebApplication.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        public CreatePersonViewModel() { }

        public CreatePersonViewModel(string name, string phone, string city, string country)
        {
            Name = name;
            Phone = phone;
            City = city;
            Country = country;
        }

    }
}
