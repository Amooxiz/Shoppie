namespace Application.ViewModels
{
    public class OfferManagementModel
    {
        public List<AppUserVM> Users { get; set; }
        public List<OfferVM> Offers { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public int SelectedCategoryId { get; set; }
    }
}
