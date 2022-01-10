using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.admin;
using Data.DataAccess;
using Domain.Entities;

namespace Data.client
{
    public class ProductsDal
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly ProductDal _productDal;

        public ProductsDal(DataAccessLayer dataAccessLayer,ProductDal productDal)
        {
            _dataAccessLayer = dataAccessLayer;
            _productDal = productDal;
        }

        public IEnumerable<Product> GetProductsByCategory(string slug)
        {
            const string sql = "usp_GetProductsByCategory";
            using var con = _dataAccessLayer.AppConn();
            var products = con.Query<Product>(sql, new {slug}, commandType: CommandType.StoredProcedure);
            foreach (var product in products)
            {
                product.ProductGalleries = _productDal.GetProductGalleries(product.ProductId).ToList();
            }
            return products;
        }

        public IEnumerable<Product> GetProductsByPrice(decimal startingPrice, decimal endingPrice)
        {
            const string sql = "usp_GetProductsByPrice";
            using var con = _dataAccessLayer.AppConn();
            var products = con.Query<Product>(sql, new {startingPrice, endingPrice},
                commandType: CommandType.StoredProcedure);
            var productsByPrice = products as Product[] ?? products.ToArray();
            foreach (var product in productsByPrice)
            {
                product.ProductGalleries = _productDal.GetProductGalleries(product.ProductId).ToList();
            }

            return productsByPrice;
        }

        public IEnumerable<Product> Sort(string type)
        {
            var sql = type == "asc" ? "usp_GetProductsByAscPrice" : "usp_GetProductsByDescPrice";
            using var con = _dataAccessLayer.AppConn();
            var products = con.Query<Product>(sql, commandType: CommandType.StoredProcedure);
            return products;
        }

        public IEnumerable<Product> GetRelatedProducts(int categoryId)
        {
            const string sql = "usp_GetRelatedProducts";
            using var con = _dataAccessLayer.AppConn();
            var products = con.Query<Product>(sql, new {categoryId}, commandType: CommandType.StoredProcedure);
            var relatedProducts = products as Product[] ?? products.ToArray();
            foreach (var product in relatedProducts)
                product.ProductGalleries = _productDal.GetProductGalleries(product.ProductId).ToList();
            return relatedProducts;
        }
    }
}