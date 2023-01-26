using Shoppie.ViewModels;

namespace Shoppie.SupportModels
{
    public class Cart
    {
        public int ItemCount { get; set; }
        public List<OfferVM> Items { get; set; }
    }
}
