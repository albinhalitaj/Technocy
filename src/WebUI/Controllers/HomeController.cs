using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly ProductManager _productManager;

        public HomeController(CategoryManager categoryManager,ProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories();
            var products = _productManager.GetProducts();
            var model = new HomeViewModel
            {
                Products = products
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}