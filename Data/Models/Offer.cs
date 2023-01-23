using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppie.DataAccess.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinished { get; set; }
        public double Discount { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
