using Microsoft.AspNetCore.Mvc;
using Shoppie.Business.ViewModels;

namespace Shoppie.Business.Generators.Interfaces
{
    public interface IPdfGenerator
    {
        public FileResult GeneratePdf(IEnumerable<OfferVM> offers, string currencyEmblem = "PLN");
    }
}
