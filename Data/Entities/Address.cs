using System.ComponentModel.DataAnnotations;

namespace Shoppie.DataAccess.Entities
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
        [RegularExpression(@"^[a-zA-Z]+(([',.\- ][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "The last name must contain only Latin letters and special characters")]
        public string BuildingNr { get; set; }
        [Display(Name = "Apartment Number - Optional")]
        public int? ApartamentNr { get; set; }
    }
}