using System;
using System.Collections.Generic;
using System.Linq;
using Application.admin;
using Application.client;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using ProductManager = Application.admin.ProductManager;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly Application.client.ProductManager _clientProductManager;
        private readonly WishlistManager _wishlistManager;
        private IEnumerable<Category> Categories { get; }
        private int TotalProdukte { get; }

        public ProductsController(ProductManager productManager,
            CategoryManager categoryManager,
            Application.client.ProductManager clientProductManager,WishlistManager wishlistManager)
        {
            _productManager = productManager;
            _clientProductManager = clientProductManager;
            _wishlistManager = wishlistManager;
            Categories = categoryManager.GetCategories().Where(x=>x.Visibility);
            TotalProdukte = _productManager.GetProducts().Count();
        }
        
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var model = _productManager.GetProducts();
            ViewBag.Categories = Categories;
            ViewBag.TotalProdukte = TotalProdukte;
            ViewBag.Produktet = model.Count();
            return View(model);
        }

        [HttpGet]
        [Route("/products/{categorySlug}")]
        public IActionResult FilterProductsByCategories(string categorySlug)
        {
            var products = _clientProductManager.GetProductsByCategory(categorySlug);
            ViewBag.Categories = Categories;
            ViewBag.TotalProdukte = TotalProdukte;
            ViewBag.Produktet = products.Count();
            return View("~/Views/Products/Index.cshtml",products);
        }

        [HttpGet]
        public IActionResult FilterProductsByPrice(string startingPrice, string endingPrice)
        {
            var products =
                _clientProductManager.GetProductsByPrice(decimal.Parse(startingPrice), decimal.Parse(endingPrice));
            ViewBag.Categories = Categories;
            ViewBag.TotalProdukte = TotalProdukte;
            ViewBag.Produktet = products.Count();
            return View("~/Views/Products/Index.cshtml", products);
        }

        [HttpGet]
        public IActionResult Sort(string type)
        {
            var products = _clientProductManager.SortProducts(type);
            ViewBag.Categories = Categories;
            ViewBag.TotalProdukte = TotalProdukte;
            ViewBag.Produktet = products.Count();
            return View("~/Views/Products/Index.cshtml",products);
        }

        
        [HttpGet]
        [Route("/product/{slug}")]
        public IActionResult Product(string slug)
        {
            ViewBag.Categories = Categories;
            ViewBag.IsInWishList = false;
            if (User.Identity?.IsAuthenticated != null && User.Identity.IsAuthenticated)
            {
                var customerWishlist = _wishlistManager.GetWishlistForCustomer(Convert.ToInt32(User.Claims.ElementAt(1).Value));
                if (customerWishlist.Any(x=>x.Product.Slug == slug))
                {
                    ViewBag.IsInWishList = true;
                }
            }
            var product = _productManager.GetProductBySlug(slug);
            if (product == null)
            {
                return RedirectToAction("Index","Home");
            }
            var productCategory = product.ProductCategories.FirstOrDefault()!.CategoryId;
            var relatedProduct = _clientProductManager.GetRelatedProducts(productCategory).ToList();
            relatedProduct.RemoveAll(x => x.ProductId == product.ProductId);
            var productDetailModel = new ProductDetailsViewModel
            {
                Product = product,
                RelatedProducts = relatedProduct.Distinct().AsEnumerable()
            };
            return View("ProductDetails",productDetailModel);
        }
    }
}