using Microsoft.EntityFrameworkCore;
using Shoppie.Extensions;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ICategoryRepository _categoryRepository;
        public OfferService(IOfferRepository offerRepository, ICategoryRepository categoryRepostiory)
        {
            _offerRepository= offerRepository;
            _categoryRepository = categoryRepostiory;
        }

        public void AddOffer(Offer offer)
        { 
            _offerRepository.AddOffer(offer);
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

        public OfferVM GetOffer(int? id)
        {
            var offer = _offerRepository.GetOffer(id);

            return new OfferVM
            {
                Id = offer.Id,
                Title = offer.Title,
                Description = offer.Description,
                Price = offer.Price,
                Discount = offer.Discount,
                CategoryName = offer.Category.Name,
                CreationDate = offer.CreationDate,
                IsActive = offer.IsActive,
                IsFinished = offer.IsFinished
            };
        }

        /*public async Task<List<OfferVM>> GetUsersOffers(string userId)
        {
            var offers = await _offerRepository.GetUsersOffers(userId).ToModel().ToListAsync(); 
            
            return offers;
        }*/
    }
}