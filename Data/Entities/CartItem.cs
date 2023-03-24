using System.ComponentModel.DataAnnotations;

namespace Shoppie.DataAccess.Entities
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public Cart Cart { get; set; }
    }
}
