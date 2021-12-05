using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Product> ProductsNew { get; set; }
        public IEnumerable<Product> DiscountProducts { get; set; }
    }
}