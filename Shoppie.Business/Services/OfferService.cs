using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            var offer = await _offerRepository.GetOfferAsync(offerVM.Id);

            MapToEntity(offerVM, offer);
            
            await _offerRepository.UpdateOfferAsync(offer);
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
            var vm = offer.ToModel();

            return vm;
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

       private void MapToEntity(OfferVM vm, Offer entity)
       {
            entity.Title = vm.Title;
            entity.Description = vm.Description;
            entity.Price = vm.Price;
            entity.Discount = vm.Discount;
            entity.CategoryId = vm.CategoryId;
            entity.IsActive = vm.IsActive;
            entity.IsFinished = vm.IsFinished;
            entity.CreationDate = vm.CreationDate;

        }
    }
}