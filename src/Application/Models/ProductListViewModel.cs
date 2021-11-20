using System.Collections.Generic;
using Domain.Entities;

namespace Application.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}