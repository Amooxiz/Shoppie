using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shoppie.Business.Attributes.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        private string[] AllowedExtensions { get; set; }
        public FileExtensionAttribute(string extensions)
        {
            AllowedExtensions = extensions.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        public override bool IsValid(object? value)
        {
            IFormFile file = value as IFormFile;
            bool IsValid = true;

            if (file is not null)
            {
                IsValid = AllowedExtensions.Any(x => file.FileName.EndsWith(x));
            }

            return IsValid;
        }
    }
}
