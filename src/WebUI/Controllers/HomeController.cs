using System.Diagnostics;
using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Categories = _categoryManager.GetCategories().Where(x=>x.Visibility);
            var model = new HomeViewModel
            {
                Products = _productManager.GetProducts(),
                ProductPromotions = _productManager.GetProductPromotions(),
                DiscountProducts = _productManager.GetDiscountProducts()
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