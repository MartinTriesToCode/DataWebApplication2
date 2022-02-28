using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApplication.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public CreateCountryViewModel()
        {

        }

        public CreateCountryViewModel(string name)
        {
            Name = name;
        }
    }
}
