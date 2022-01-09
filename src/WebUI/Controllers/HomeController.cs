using System.Diagnostics;
using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductManager _productManager;

        public HomeController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Products = _productManager.GetProducts(),
                ProductsNew = _productManager.GetProductNew(),
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