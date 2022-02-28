

using System.ComponentModel.DataAnnotations;

namespace DataWebApplication.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Key]
        public int ID { get; set; }

       
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public CreateCityViewModel()
        {

        }

        public CreateCityViewModel(string name)
        {
            Name = name;
        }

    }
}
