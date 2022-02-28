using System;
using System.Collections.Generic;
using DataWebApplication.Models.Entities;

namespace DataWebApplication.Models.ViewModels
{
    public class CityViewModel
    {
        public List<City> Cities { get; set; }
        public CreateCityViewModel CreateCityVM { get; set; }
    }
}
