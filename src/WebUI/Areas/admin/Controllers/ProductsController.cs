using System.Collections.Generic;
using Application.admin;
using Application.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotyfService _notyf;

        public ProductsController(ProductManager productManager,
            CategoryManager categoryManager,IWebHostEnvironment webHostEnvironment,
            INotyfService notyf)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
        }
        
        // GET
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Categories = _categoryManager.GetCategories(),
                Products = _productManager.GetProducts()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult New()
        {
            var categories = _categoryManager.GetCategories();
            var model = new InsertProductModel
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult New(InsertProductModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productManager.Add(model,model.ProductCategories,_webHostEnvironment.WebRootPath);
                if (result)
                {
                    _notyf.Custom("Produkti u shtua me sukses!", 5, "#FFBC53", "fa fa-check");
                    return RedirectToAction(nameof(Index));
                }
                _notyf.Error("Diqka shkoi gabim! Ju lutem provoni përseri",5);
            }
            return View(model);
        }

        public IActionResult Filtro()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}