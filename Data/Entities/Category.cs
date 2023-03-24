namespace Shoppie.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
