namespace Shoppie.ViewModels
{
    public class OfferVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinished { get; set; }
        public double Discount { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
