using System;
using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccountManager = Application.client.AccountManager;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly AccountManager _accountManager;

        public ProfileController(CategoryManager categoryManager,AccountManager accountManager)
        {
            _categoryManager = categoryManager;
            _accountManager = accountManager;
        }
        
        // GET
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x=>x.Visibility);
            var user = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            var customer = _accountManager.GetCustomerById(user);
            return View(customer);
        }
    }
}