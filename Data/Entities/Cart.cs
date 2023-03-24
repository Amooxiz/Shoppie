namespace Shoppie.DataAccess.Entities
{
    public class Cart
    {
        public int CartId { get; set; }

        public string? AnnoynymousCartOwnerId { get; set; }

        public string? AuthenticatedCartOwnerId { get; set; }

        public AppUser AuthenticatedCartOwner { get; set; }

        public bool IsFinished { get; set; } = false;
        public DateTime? FinishDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public ICollection<CartItem> Items { get; set; }
    }
}