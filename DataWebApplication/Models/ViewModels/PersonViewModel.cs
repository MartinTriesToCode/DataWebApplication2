using System.Collections.Generic;
using DataWebApplication.Models.Entities;

namespace DataWebApplication.Models.ViewModels
{
    public class PersonViewModel
    {
        public List<Person> People { get; set; }
        public CreatePersonViewModel CreateViewModel { get; set; }

    }
}
