using System;
using System.Linq;
using Application.admin;
using Application.client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using AccountManager = Application.client.AccountManager;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly AccountManager _accountManager;
        private readonly OrderService _orderService;

        public ProfileController(CategoryManager categoryManager,AccountManager accountManager,
            OrderService orderService)
        {
            _categoryManager = categoryManager;
            _accountManager = accountManager;
            _orderService = orderService;
        }
        
        // GET
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x=>x.Visibility);
            var customerOrders = _orderService.GetCustomerOrders(Convert.ToInt32(User.Claims.ElementAt(1).Value));
            var user = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            var customer = _accountManager.GetCustomerById(user);
            var profile = new ProfileViewModel()
            {
                Customer = customer,
                Orders = customerOrders
            };
            return View(profile);
        }
    }
}