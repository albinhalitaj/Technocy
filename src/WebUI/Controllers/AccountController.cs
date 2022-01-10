using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.admin;
using Application.client.Data;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using AccountManager = Application.client.AccountManager;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly AccountManager _accountManager;
        private readonly INotyfService _notyf;

        public AccountController(CategoryManager categoryManager,AccountManager accountManager,
            INotyfService notyf)
        {
            _categoryManager = categoryManager;
            _accountManager = accountManager;
            _notyf = notyf;
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
                var result = _accountManager.Register(model);
                if (result)
                {
                    // registration succeeded
                    return RedirectToAction("Index", "Home");
                }
                _notyf.Error("Ndodhi një gabim! Ju lutem provoni përsëri.", 5);
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
        public IActionResult Login(string returnUrl)
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            ViewBag.ReturnUrl = returnUrl;
            if (User.Identity is {IsAuthenticated: true})
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            if (ModelState.IsValid)
            {
                var customer = _accountManager.Login(model);
                
                if (customer != null)
                {
                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.Name, string.Concat(customer.Name, " ", customer.Surname)),
                        new ("Id", customer.CustomerId.ToString()),
                        new (ClaimTypes.Email, customer.Email),
                    };

                    var identityPrincipal =
                        new ClaimsIdentity(claims, "User_Schema");
                    
                    var claimPrincipal = new ClaimsPrincipal(identityPrincipal);
                    await HttpContext.SignInAsync("User_Schema",claimPrincipal);
                    if (!string.IsNullOrEmpty(returnUrl))
                        return LocalRedirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                _notyf.Error("Përdoruesi ose fjalëkalimi është gabim!", 5);
            }
            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            if (HttpContext.Request.Cookies.ContainsKey(".AspNetCore.User_Schema"))
            {
                await HttpContext.SignOutAsync("User_Schema");
            }
            else
            {
                await HttpContext.SignOutAsync("Admin_Schema");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}