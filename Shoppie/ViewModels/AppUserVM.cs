namespace Shoppie.ViewModels
{
    public class AppUserVM
    {
        public string Id { get; set; }

        [Display(Name = "Street address")]
        public string Street { get; set; }
        
        [Display(Name = "Apartament number")]
        public int? ApartamentNr { get; set; }
        
        [Display(Name = "Building number")]
        public string BuildingNr { get;  set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Display(Name = "Country")]
        public string Country { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Personal discount")]
        public double PersonalDicount { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}
