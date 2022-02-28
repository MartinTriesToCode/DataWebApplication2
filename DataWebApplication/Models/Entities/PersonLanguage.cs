

using System.Collections.Generic;

namespace DataWebApplication.Models.Entities
{
    public class PersonLanguage
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
      

        public int LanguageId { get; set; }
        public Language Language { get; set; }
       
    }
}
