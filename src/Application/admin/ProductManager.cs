using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using Application.Models;
using AutoMapper;
using Data.admin;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

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

        private async Task<bool> Upload(IFormFileCollection files, int productId, string webRootPath)
        {
            const string folder = "Admin/images/products/";
            
            var productGallery = new List<ProductGallery>();
            if (files.Count > 0)
            {
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
            return false;
        }

        public IEnumerable<Product> Filtro(ProductFilterModel model)
        {
            return _productManager.FilterProducts(model.StartingPrice, model.EndingPrice, model.Visibility,model.Categories);
        }

        public InsertProductModel FirstOrDefault(int productId)
        {
            var product = _productManager.GetProduct(productId);
            var productModel = _mapper.Map<InsertProductModel>(product);

            productModel.Categories = _categoryManager.GetCategories();
            
            var productCategories = _productManager.GetProductCategories(productId).ToList();
            var temp = new List<string>();
            if (productModel != null)
            {
                temp.AddRange(productCategories
                        .Select(productCategory => productCategory.CategoryId.ToString()));
            }

            productModel.ProductCategories = temp;
            var productGalleries = _productManager.GetProductGalleries(productId);
            return productModel;
        }

        public IEnumerable<Product> GetProducts() => _productManager.GetProducts();

        public bool Remove(int productId,string webRootPath)
        {
            var productGalleries = _productManager.GetProductGalleries(productId);

            if (productGalleries.Any())
            {
            
                foreach (var productGallery in productGalleries)
                {
                    var url = productGallery.URL.Remove(0, 1);
                    var uploadsFolder = Path.Combine(webRootPath, url);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
            _productManager.DeleteProductGalleries(productId);
            var deleteProductCategories = _productManager.DeleteProductCategories(productId);    
            var result = _productManager.DeleteProduct(productId);

            return deleteProductCategories && result;
        }
    }
}