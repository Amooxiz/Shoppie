namespace Shoppie.DataAccess.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public string? AuthenticatedUserId { get; set; }
        public string? AnnoynymousUserCookieId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}