using System.Collections.Generic;
using System.Linq;
using Application.admin;
using Application.client.Data;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public AccountController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult GetCitiesByCountry(string country)
        {
            var result = country switch
            {
                "Kosovë" => KosovoCities.GetCities(),
                "Shqipëri" => AlbaniaCities.GetCities(),
                "Maqedoni" => MacedoniaCities.GetCities(),
                _ => null
            };
            return Json(new {data = result});
        }

        [HttpGet]
        [Route("/account")]
        [Route("/account/login")]
        public IActionResult Login()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}