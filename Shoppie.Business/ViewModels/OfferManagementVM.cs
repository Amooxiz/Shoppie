namespace Shoppie.Business.ViewModels
{
    public class OfferManagementVM
    {
        public List<OfferVM> Offers { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}
