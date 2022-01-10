using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}