using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("/admin")]
        [Route("/admin/account")]
        [Route("/admin/account/login")]
        public IActionResult Login(string returnUrl)
        {
            try
            {
                if (User.Identity.IsAuthenticated && User.Claims.Any(x=>x.Type == ClaimTypes.Role))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                            new ("Username",employee.Username),
                            new (ClaimTypes.Email, employee.Email),
                            new (ClaimTypes.Role, employee.Role.Name)
                        };

                        if (HttpContext.Request.Cookies.ContainsKey(".AspNetCore.User_Schema"))
                        {
                            await HttpContext.SignOutAsync("User_Schema");
                        }
                        
                        var identityPrincipal =
                            new ClaimsIdentity(claims,"Admin_Schema");
                        var claimPrincipal = new ClaimsPrincipal(identityPrincipal);
                        await HttpContext.SignInAsync("Admin_Schema",claimPrincipal);
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
            await HttpContext.SignOutAsync("Admin_Schema");
            return RedirectToAction(nameof(Login));
        }

    }
}