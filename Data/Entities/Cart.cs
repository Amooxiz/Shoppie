using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppie.DataAccess.Entities
{
    [PrimaryKey($"{nameof(CartId)}", $"{nameof(AnnoynymousCartOwnerId)}", $"{nameof(AuthenticatedCartOwnerId)}")]
    public class Cart
    {
        public int CartId { get; set; }
        
        public string? AnnoynymousCartOwnerId { get; set; }
                
        public string? AuthenticatedCartOwnerId { get; set; }
        
        public AppUser AuthenticatedCartOwner { get; set; }
        
        public bool IsFinished { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public ICollection<CartItem> Items { get; set; }
    }
}