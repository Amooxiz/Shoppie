using Microsoft.AspNetCore.Http;

namespace Shoppie.Business.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> ProcessImage(IFormFile image);
    }
}