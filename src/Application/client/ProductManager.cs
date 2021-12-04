using System.Collections.Generic;
using Data.client;
using Domain.Entities;

namespace Application.client
{
    public class ProductManager
    {
        private readonly ProductsDal _productsDal;

        public ProductManager(ProductsDal productsDal)
        {
            _productsDal = productsDal;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId) =>
            _productsDal.GetProductsByCategory(categoryId);

        public IEnumerable<Product> GetProductsByPrice(decimal startingPrice, decimal endingPrice) =>
            _productsDal.GetProductsByPrice(startingPrice, endingPrice);

        public IEnumerable<Product> SortProducts(string type) =>
            _productsDal.Sort(type);
    }
}