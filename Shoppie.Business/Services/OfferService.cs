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

        public async Task AddOfferAsync(Offer offer)
        {
            await _offerRepository.AddOfferAsync(offer);
        }

        public async Task UpdateOfferAsync(OfferVM offerVM)
        {
            var offerEntity = await _offerRepository.GetOfferAsync(offerVM.Id);

            offerEntity.Title = offerVM.Title;
            offerEntity.Description = offerVM.Description;
            offerEntity.Price = offerVM.Price;
            offerEntity.Discount = offerVM.Discount;
            offerEntity.CategoryId = offerVM.CategoryId;
            offerEntity.IsActive = offerVM.IsActive;
            offerEntity.IsFinished = offerVM.IsFinished;
            offerEntity.CreationDate = offerVM.CreationDate;

            await _offerRepository.UpdateOfferAsync(offerEntity);
        }

        public async Task<List<OfferVM>> GetAllActiveOffersAsync()
        {
            var offers = await _offerRepository.GetAllActiveOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetAllOffersAsync()
        {
            var offers = await _offerRepository.GetAllOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetDiscountedOffersAsync()
        {
            var offers = await _offerRepository.GetDiscountedOffers().ToModel().ToListAsync();

            return offers;
        }

        public async Task<List<OfferVM>> GetNewOffersAsync(int count)
        {
            var offers = await _offerRepository.GetNewOffers(count).ToModel().ToListAsync();

            return offers;
        }

        public async Task<OfferVM> GetOfferAsync(int? id)
        {
            var offer = await _offerRepository.GetOfferAsync(id);

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

        public async Task DeleteOfferAsync(int id)
        {
            var offer = await _offerRepository.GetOfferAsync(id);
            await _offerRepository.DeleteOfferAsync(offer);
        }

        public Task<List<OfferVM>> GetOffersByCategoryIdAsync(int id)
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