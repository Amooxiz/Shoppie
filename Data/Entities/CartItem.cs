using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
