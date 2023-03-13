using System.ComponentModel.DataAnnotations;

namespace Shoppie.Business.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
    }
}
