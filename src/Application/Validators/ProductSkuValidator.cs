using System.ComponentModel.DataAnnotations;
using Application.admin;

namespace Application.Validators
{
    public class ProductSkuValidator : ValidationAttribute
    {
        private static string GetErrorMessage() => "Kodi i produktit duhet te jete unik";
        
        protected override ValidationResult IsValid(object? value,ValidationContext validationContext)
        {
            var service = (ProductManager) validationContext
                .GetService(typeof(ProductManager));
            var sku = service.GetProductSku(value.ToString());
            return !string.IsNullOrEmpty(sku) ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }
    }
}