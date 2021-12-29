using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Models;
using AutoMapper;
using Data.admin;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.admin
{
    public class ProductManager
    {
        private readonly ProductDal _productManager;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        private readonly CategoryDal _categoryManager;

        public ProductManager(ProductDal productManager,
            IMapper mapper,
            IFileManager fileManager,
            CategoryDal categoryManager)
        {
            _productManager = productManager;
            _mapper = mapper;
            _fileManager = fileManager;
            _categoryManager = categoryManager;
        }

        public bool Add(InsertProductModel model, IEnumerable<string> categories,string webRootPath)
        {
            var product = _mapper.Map<Product>(model);
            
            product.Status = true;
            product.InsertDate = DateTime.Now;
            
            var id = _productManager.Insert(product);

            foreach (var category in categories)
            {
                product.ProductCategories.Add(new ProductCategory
                {
                    ProductId = id,
                    CategoryId = int.Parse(category)
                });
            }

            var res = _productManager.InsertProductCategories(product.ProductCategories);
            var status = Upload(model.ProductGallery, id, webRootPath).Result; 
            
            return res && status;
        }

        public bool Edit(EditProductModel model, IEnumerable<string> categories,string webRootPath)
        {
            var product = _mapper.Map<Product>(model);

            product.Status = product.Stock > 0;
            product.LastUpdatedDate = DateTime.Now;

            _productManager.DeleteProductCategories(model.ProductId);
            var res = _productManager.Update(product);
            var status = true;
            if (!res) return res && status;
            foreach (var category in categories)
            {
                product.ProductCategories.Add(new ProductCategory
                {
                    ProductId = product.ProductId,
                    CategoryId = int.Parse(category)
                });
            }
            _productManager.InsertProductCategories(product.ProductCategories);
            if (model.ProductGallery != null && model.ProductGallery.Any())
            {
                status = Upload(model.ProductGallery, product.ProductId, webRootPath).Result;
            }

            return res && status;
        }

        private async Task<bool> Upload(IFormFileCollection files, int productId, string webRootPath)
        {
            const string folder = "Admin/images/products/";
            
            var productGallery = new List<ProductGallery>();
            if (files.Count <= 0) return false;
            foreach (var file in files)
            {
                var gallery = new ProductGallery
                {
                    ProductId = productId,
                    Name = file.FileName,
                    URL = await _fileManager.Upload(folder, file, webRootPath)
                };
                productGallery.Add(gallery);
            }
            var result = _productManager.InsertProductGallery(productGallery);
            return result;
        }

        public IEnumerable<Product> Filtro(ProductFilterModel model) =>
            _productManager.FilterProducts(model.StartingPrice, model.EndingPrice, model.Visibility,model.Categories);

        public EditProductModel FirstOrDefault(int productId)
        {
            var product = _productManager.GetProduct(productId);
            var productModel = _mapper.Map<EditProductModel>(product);
            
            var productCategories = _productManager.GetProductCategories(productId).ToList();
            var temp = new List<string>();
            if (productModel != null)
            {
                temp.AddRange(productCategories
                        .Select(productCategory => productCategory.CategoryId.ToString()));
            }
            
            var productGalleries = _productManager.GetProductGalleries(productId);
            if (product == null) return productModel;
            if (productModel == null) return null;
            productModel.ProductCategories = temp;
            productModel.Categories = _categoryManager.GetCategories();
            productModel.ProductGalleries = productGalleries;

            return productModel;

        }

        public Product GetProductBySlug(string slug) => _productManager.GetProductBySlug(slug);

        public IEnumerable<Product> GetProducts() => _productManager.GetProducts(ProductTypes.Products);

        public IEnumerable<Product> GetProductNew() => _productManager.GetProducts(ProductTypes.ProductPromotions);
        public IEnumerable<Product> GetDiscountProducts() => _productManager.GetProducts(ProductTypes.DiscountProducts);

        public bool Remove(int productId,string webRootPath)
        {
            var productGalleries = _productManager.GetProductGalleries(productId);

            var enumerable = productGalleries as ProductGallery[] ?? productGalleries.ToArray();
            if (enumerable.Any())
            {
                foreach (var productGallery in enumerable)
                {
                    var url = productGallery.URL.Remove(0, 1);
                    _fileManager.Delete(url, webRootPath);
                }
            }
            _productManager.DeleteProductGalleries(productId);
            var deleteProductCategories = _productManager.DeleteProductCategories(productId);    
            var result = _productManager.DeleteProduct(productId);

            return deleteProductCategories && result;
        }

        public bool RemoveProductImages(string name,int productId,string webRootPath)
        {
            var productGalleries = _productManager.GetProductGalleries(productId);
            var status = false;
            if (productGalleries.Count() == 1)
            {
                return status;
            }
            foreach (var productGallery  in productGalleries)
            {
                if (productGallery.Name != name) continue;
                var url = productGallery.URL.Remove(0, 1);
                _fileManager.Delete(url, webRootPath);
                _productManager.DeleteProductImage(productGallery.URL);
                status = true;
                break;
            }
            return status;
        }

        public string GetProductSku(string sku) => _productManager.GetProductSku(sku);

        public Product GetProductById(int id) => _productManager.GetProductById(id);
    }
}