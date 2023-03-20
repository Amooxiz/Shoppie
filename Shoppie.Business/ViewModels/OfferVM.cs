using Microsoft.AspNetCore.Http;
using Shoppie.Business.Attributes.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shoppie.Business.ViewModels
{
    public class OfferVM
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [MinLength(5, ErrorMessage = "The description must be at least 5 characters long")]
        [MaxLength(40)]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [MaxLength(255)]
        [MinLength(30, ErrorMessage = "The description must be at least 30 characters long")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }

        [Display(Name = "Is finished")]
        public bool IsFinished { get; set; }

        [Display(Name = "Discount")]
        [Range(0, 100)]
        public double Discount { get; set; } = 0;

        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "Category name")]
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        
        [Display(Name = "Image")]
        [MaxSize(5242880, ErrorMessage = "The maximum size of an image is 5MB")]
        [FileExtension(".jpg,.jpeg,.png", ErrorMessage = "The accepted image formats are: .jpg, .jpeg, .png")]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
