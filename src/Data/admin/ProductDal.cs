using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class ProductDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public ProductDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public int Insert(Product product)
        {
            using var con = _dataAccessLayer.AppConn();
            const string insertProduct = "usp_InsertProduct";
            var paramValues = new DynamicParameters();
            paramValues.Add("name",product.Name);
            paramValues.Add("slug",product.Slug);
            paramValues.Add("summary",product.Summary);
            paramValues.Add("description",product.Description);
            paramValues.Add("visibility",product.Visibility);
            paramValues.Add("stock",product.Stock);
            paramValues.Add("sku",product.SKU);
            paramValues.Add("price",product.Price);
            paramValues.Add("oldPrice",product.OldPrice);
            paramValues.Add("status",product.Status);
            paramValues.Add("metaTitle",product.MetaTitle);
            paramValues.Add("metaDescription",product.MetaDescription);
            paramValues.Add("insertDate",product.InsertDate);
            paramValues.Add("new_identity",dbType: DbType.Int32,direction: ParameterDirection.Output);

            var result = con.ExecuteAsync(insertProduct,paramValues, commandType: CommandType.StoredProcedure)
                .Result;

            var id = 0;
            
            if (result == 1)
            {
                id = paramValues.Get<int>("new_identity");
            }
            return id;
        }

        public IEnumerable<Product> GetProducts()
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_GetProducts";
            var products = con.QueryAsync<Product>(sql, commandType: CommandType.StoredProcedure)
                .Result;
            var mappedProducts = new List<Product>();
            foreach (var product in products)
            {
                product.ProductCategories = GetProductCategories(product.ProductId).ToList();
                product.ProductGalleries = GetProductGalleries(product.ProductId).ToList();
                mappedProducts.Add(product);
            }
            return mappedProducts;
        }

        private IEnumerable<ProductCategory> GetProductCategories(int productId)
        {
            const string sql = "usp_GetProductCategories";
            using var con = _dataAccessLayer.AppConn();
            var productCategories = con.Query<ProductCategory, Category, ProductCategory>(sql,
                    (productCategory, category) =>
                    {
                        productCategory.Category = category;
                        return productCategory;
                    },splitOn: "Name",commandType: CommandType.StoredProcedure,param: new {productId})
                .ToList();
            return productCategories;
        }

        private IEnumerable<ProductGallery> GetProductGalleries(int productId)
        {
            const string productGallerysql = "usp_GetProductGallery"; 
            using var con = _dataAccessLayer.AppConn();
            var productGallery = con.Query<ProductGallery>(productGallerysql,
                new {productId}, commandType: CommandType.StoredProcedure);
            return productGallery;
        }

        public bool InsertProductGallery(IEnumerable<ProductGallery> productGalleries)
        {
            const string insertGallery = "usp_InsertProductGallery";
            using var con = _dataAccessLayer.AppConn();
            bool status;
            try
            {
                foreach (var values in productGalleries.Select(image => new
                {
                    productId = image.ProductId,
                    name = image.Name,
                    url = image.URL
                }))
                {
                    con.Execute(insertGallery, values, commandType: CommandType.StoredProcedure);
                }

                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return status;
        }

        public bool InsertProductCategories(IEnumerable<ProductCategory> productCategories)
        {
            const string sql = "usp_InsertProductCategories";
            using var con = _dataAccessLayer.AppConn();
            var rowsAffected = productCategories.Select(
                productCategory => new
                {
                    productId = productCategory.ProductId,
                    categoryId = productCategory.CategoryId
                })
                .Select(values => 
                    con.Execute(sql, values, commandType: CommandType.StoredProcedure))
                .Count(res => res == 1);
            return rowsAffected == productCategories.Count();
        }

        public IEnumerable<Product> FilterProducts
            (decimal startingPrice,decimal endingPrice,bool visibility,IEnumerable<string> cats)
        {
            const string sql = "usp_FilterProducts";
            using var con = _dataAccessLayer.AppConn();
            var result = string.Join(",", cats);
            var values = new
            {
                startingPrice,
                endingPrice,
                visibility,
                categories = result
            };
            var products = con.Query<Product>(sql,values,commandType: CommandType.StoredProcedure).ToList();
            var mappedProducts = new List<Product>();
            foreach (var product in products)
            {
                product.ProductCategories = GetProductCategories(product.ProductId).ToList();
                product.ProductGalleries = GetProductGalleries(product.ProductId).ToList();
                mappedProducts.Add(product);
            }
            return mappedProducts;
        }
    }
}