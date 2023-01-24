using System.ComponentModel.DataAnnotations;

namespace Shoppie.DataAccess.Models
{
    public class Address
    {
        public int Id { get; set; }
        
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
       
        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [Display(Name = "Building Number")]
        public string BuildingNr { get; set; }
        [Display(Name = "Apartment Number - Optional")]
        public int? ApartamentNr { get; set; }
    }
}