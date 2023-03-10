using Microsoft.EntityFrameworkCore;
using Shoppie.Business.Extensions.VM;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.Business.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ICategoryRepository _categoryRepository;
        public OfferService(IOfferRepository offerRepository, ICategoryRepository categoryRepostiory)
        {
            _offerRepository = offerRepository;
            _categoryRepository = categoryRepostiory;
        }

        public async Task AddOffer(Offer offer)
        {
            await _offerRepository.AddOffer(offer);
        }

        public async Task UpdateOffer(OfferVM offerVM)
        {
            var offerEntity = await _offerRepository.GetOffer(offerVM.Id);

            offerEntity.Title = offerVM.Title;
            offerEntity.Description = offerVM.Description;
            offerEntity.Price = offerVM.Price;
            offerEntity.Discount = offerVM.Discount;
            offerEntity.CategoryId = offerVM.CategoryId;
            offerEntity.IsActive = offerVM.IsActive;
            offerEntity.IsFinished = offerVM.IsFinished;
            offerEntity.CreationDate = offerVM.CreationDate;

            await _offerRepository.UpdateOffer(offerEntity);
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

        public async Task<OfferVM> GetOffer(int? id)
        {
            var offer = await _offerRepository.GetOffer(id);

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

        public async Task DeleteOffer(int id)
        {
            var offer = await _offerRepository.GetOffer(id);
            await _offerRepository.DeleteOffer(offer);
        }

        public Task<List<OfferVM>> GetOffersByCategoryId(int id)
        {
            var offers = _offerRepository.GetOffersByCategoryId(id);

            return offers.ToModel().ToListAsync();
        }

        /*public async Task<List<OfferVM>> GetUsersOffers(string userId)
        {
            var offers = await _offerRepository.GetUsersOffers(userId).ToModel().ToListAsync(); 
            
            return offers;
        }*/
    }
}