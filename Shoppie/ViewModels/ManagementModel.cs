using Shoppie.DataAccess.Models;

namespace Shoppie.ViewModels
{
    public class ManagementModel
    {
        public List<AppUserVM> Users { get; set; }
        public List<OfferVM> Offers { get; set; }
        public List<CategoryVM> Categories { get; set; }

        public int SelectedCategoryId { get; set; }
    }
}
