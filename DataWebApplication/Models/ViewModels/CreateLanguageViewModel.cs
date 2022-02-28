using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataWebApplication.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Key]
        public int LanguageId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public CreateLanguageViewModel()
        {

        }

        public CreateLanguageViewModel(int id, string name)
        {
            LanguageId = id;
            Name = name;
        }
    }
}
