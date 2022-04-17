using DataWebApplication.Data;
using DataWebApplication.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            List<Person> people = _context.People
                .Include("City")
                .Include("Country")
                .Include("Languages")
                .Include(p => p.PersonLanguages)
                .ThenInclude(p => p.Language)
                .ToList();

            

            List<ReactModel> peopleDto = new List<ReactModel>();

            foreach(var person in people)
            {
                ReactModel personDto = new ReactModel();
                personDto.PersonId = person.PersonId;
                personDto.Name = person.Name;
                personDto.Phone = person.Phone;
                personDto.City = person.City.Name;
                personDto.Country = person.Country.Name;
                personDto.Languages = new List<string>();
                personDto.Cities = new List<string>();
                personDto.Countries = new List<string>();
                personDto.LanguageList = new List<string>();
                foreach(var item in person.PersonLanguages)
                {
                    personDto.Languages.Add(item.Language.Name);
                }
                foreach (var item in _context.Countries)
                {
                    personDto.Countries.Add(item.Name);
                }
                foreach (var item in _context.Cities)
                {
                    personDto.Cities.Add(item.Name);
                }

                foreach(var item in _context.Languages)
                {
                    personDto.LanguageList.Add(item.Name);
                }

                personDto.Cities = personDto.Cities.Distinct().ToList<string>();
                personDto.Countries = personDto.Countries.Distinct().ToList<string>();
                personDto.LanguageList = personDto.LanguageList.Distinct().ToList<string>();
                peopleDto.Add(personDto);
            }
            
            string reactList = JsonSerializer.Serialize(peopleDto);
            return reactList;
        }

        [HttpPost]
        public void Post(ReactModel personDto)
        {
            

            if (ModelState.IsValid)
            {
                //Create country and add to database
                Country country = new Country { Name = personDto.Country };
                _context.Countries.Add(country);
                _context.SaveChanges();

                //Create city and add to database
          
                City city = new City { Name = personDto.City, CountryId = country.Id };
               
                _context.Cities.Add(city);
                _context.SaveChanges();

                List<Language> langList = new List<Language>();
                foreach(var item in personDto.Languages)
                {
                    Language language = new Language { Name = item.ToString() };
                    langList.Add(language);
                }

                

                Person person = new Person
                {

                    Name = personDto.Name,
                    Phone = personDto.Phone,
                    City = city,
                    Country = country,
                    PersonLanguages = new List<PersonLanguage>()
                };
               
                foreach(var item in langList)
                {
                    person.PersonLanguages.Add(new PersonLanguage { Language = item });
                }

                _context.People.Add(person);
                _context.SaveChanges();
            }

        }

        
        public void Delete([FromBody] string value)
        {
            int id = int.Parse(value);
            _context.People.Remove(_context.People.Find(id));
            _context.SaveChanges();

        }

    }
 }
