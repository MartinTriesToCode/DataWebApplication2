using System;
using System.Collections.Generic;
using DataWebApplication.Models.Entities;

namespace DataWebApplication.Models.ViewModels
{
    public class CountryViewModel
    {

        public List<Country> Countries { get; set; }
        public CreateCountryViewModel CreateCountryVM { get; set; }
    }
}
