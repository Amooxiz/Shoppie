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
        private readonly IImageService _imageService;
        public OfferService(IOfferRepository offerRepository, IImageService imageService)
        {
            _offerRepository = offerRepository;
            _imageService = imageService;
        }

        public async Task AddOfferAsync(OfferVM vM)
        {
            vM.ImagePath = await _imageService.ProcessImage(vM.Image);
            Offer offer = new();

            MapToEntity(vM, offer);

            await _offerRepository.AddOfferAsync(offer);
        }

        public async Task UpdateOfferAsync(OfferVM offerVM)
        {
            if (offerVM.Image is not null)
            {
                offerVM.ImagePath = await _imageService.ProcessImage(offerVM.Image);
            }

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

        public async Task<List<OfferVM>> GetOffersByCategoryIdAsync(int id) 
        {
            var offers = _offerRepository.GetOffersByCategoryId(id);

            return await offers.ToModel().ToListAsync();
        }

        private static void MapToEntity(OfferVM vm, Offer entity)
        {
            entity.Title = vm.Title;
            entity.Description = vm.Description;
            entity.Price = vm.Price;
            entity.Discount = vm.Discount;
            entity.CategoryId = vm.CategoryId;
            entity.IsActive = vm.IsActive;
            entity.IsFinished = vm.IsFinished;
            entity.CreationDate = vm.CreationDate;
            entity.ImagePath = vm.ImagePath;
        }

        public async Task<(List<OfferVM>, int)> GetAllOffersPaginatedAsync(int pageNumber, int pageSize)
        {
            ( var offers, var totalCount ) = _offerRepository.GetAllOffersPaginated(pageNumber, pageSize);

            return ( await offers
                .ToModel()
                .ToListAsync(), totalCount );
        }

        public async Task<(List<OfferVM>, int)> GetDiscountedOffersPaginatedAsync(int pageNumber, int pageSize)
        {
            (var offers, var totalCount) = _offerRepository.GetDiscountedOffersPaginated(pageNumber, pageSize);

            return (await offers
                .ToModel()
                .ToListAsync(), totalCount);
        }

        public async Task<(List<OfferVM>, int)> GetNewOffersPaginatedAsync(int pageNumber, int pageSize, int count)
        {
            (var offers, var totalCount) = _offerRepository.GetNewOffersPaginated(pageNumber, pageSize, count);

            return (await offers
                .ToModel()
                .ToListAsync(), totalCount);
        }
    }
}