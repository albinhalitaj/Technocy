using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class ProductsViewModel
    {
        private IEnumerable<Product> Products { get; set; }
        
    }
}