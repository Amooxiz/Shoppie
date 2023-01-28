using Shoppie.ViewModels;

using Microsoft.CodeAnalysis.Diagnostics;

namespace Shoppie.Interfaces
{
    public interface IPdfGenerator
    {
        public FileResult GeneratePdf(IEnumerable<OfferVM> offers, string currencyEmblem = "PLN");
    }
}
