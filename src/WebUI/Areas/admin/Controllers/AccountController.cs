using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.admin;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.admin.Models;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AccountManager _accountManager;
        private readonly INotyfService _notyf;

        public AccountController(AccountManager accountManager,INotyfService notyf)
        {
            _accountManager = accountManager;
            _notyf = notyf;
        }
        
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity is {IsAuthenticated: true})
                return RedirectToAction("Index", "Dashboard");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var employee = _accountManager.Login(model.Username, model.Password);
                
                if (employee != null)
                {
                    if (employee.Status)
                    {
                        var claims = new List<Claim>
                        {
                            new (ClaimTypes.Name, string.Concat(employee.Name, " ", employee.Surname)),
                            new ("Id", Convert.ToString(employee.EmployeeId)),
                            new (ClaimTypes.Email, employee.Email),
                            new (ClaimTypes.Role, employee.Role.Name)
                        };

                        var identityPrincipal =
                            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimPrincipal = new ClaimsPrincipal(identityPrincipal);
                        await HttpContext.SignInAsync(claimPrincipal);
                        if (!string.IsNullOrEmpty(returnUrl))
                            return LocalRedirect(returnUrl);
                        return RedirectToAction("Index", "Dashboard");
                    }
                    _notyf.Error("Llogaria juaj është joaktive!", 5);
                }
                else 
                    _notyf.Error("Përdoruesi ose fjalëkalimi është gabim!", 5);
            }
            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}