namespace Shoppie.ViewModels
{
    public class OfferVM
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

        [Display(Name = "Is active")]
        public bool IsActive { get; set; }

        [Display(Name = "Is finished")]
        public bool IsFinished { get; set; }

        [Display(Name = "Discount")]
        [Range(0,100)]
        public double Discount { get; set; } = 0;

        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Category name")]
        public string? CategoryName { get; set; }

        public int CategoryId { get; set; }
    }
}
