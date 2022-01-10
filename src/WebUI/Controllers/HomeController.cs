using System;
using System.Diagnostics;
using Application.admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
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

        [HttpPost]
        public IActionResult ChangeCulture(string culture)
        {
            Response.Cookies.Append
                (CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}