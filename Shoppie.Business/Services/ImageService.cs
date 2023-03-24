using Microsoft.AspNetCore.Http;
using Shoppie.Business.Services.Interfaces;
using System.Security.Cryptography;

namespace Shoppie.Business.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> ProcessImage(IFormFile image)
        {
            var secureFileName = GenerateSecurePath(15, image.FileName);
            var storagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", secureFileName);

            using (var loadedImage = await Image.LoadAsync(image.OpenReadStream()))
            {
                loadedImage.Mutate(x => x.Resize(216, 152));
                await loadedImage.SaveAsync(storagePath);
            }

            var dBPath = "Images/" + secureFileName;

            return dBPath;
        }
        private static string GenerateSecurePath(int length, string fileName)
        {
            var secureSignature = Convert.ToBase64String(RandomNumberGenerator.GetBytes(length));
            var extension = Path.GetExtension(fileName);

            return String.Concat("/", secureSignature, extension);
        }
    }
}
