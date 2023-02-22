namespace Shoppie.DataAccess.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}