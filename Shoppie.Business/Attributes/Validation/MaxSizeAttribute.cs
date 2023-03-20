using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Shoppie.Business.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;
        public MaxSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        public override bool IsValid(object? value)
        {
            IFormFile? file = value as IFormFile;
            bool isValid = true;            

            if (file is not null)
            {
                isValid = file.Length <= _maxSize;
            }

            return isValid;
        }
    }
}
