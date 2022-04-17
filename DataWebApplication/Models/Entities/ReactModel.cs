using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApplication.Models.Entities
{
    public class ReactModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<string> Cities { get; set; }
        public List<string> Countries { get; set; }
        public List<string> Languages { get; set; }
        public List<string> LanguageList { get; set; }
    }
}
