using Microsoft.EntityFrameworkCore;
using Shoppie.Extensions;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository= offerRepository;
        }

        public async Task<List<OfferVM>> GetAllActiveOffers()
        {
            var offers = await _offerRepository.GetAllActiveOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetAllOffers()
        {
            var offers = await _offerRepository.GetAllOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetDiscountedOffers()
        {
            var offers = await _offerRepository.GetDiscountedOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetNewOffers(int count)
        {
            var offers = await _offerRepository.GetNewOffers(count).ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetUsersOffers(string userId)
        {
            var offers = await _offerRepository.GetUsersOffers(userId).ToModel().ToListAsync(); 
            
            return offers;
        }
    }
}