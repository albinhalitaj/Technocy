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
        private readonly AccountManager _accountManager;
        private readonly OrderService _orderService;

        public ProfileController(AccountManager accountManager,
            OrderService orderService)
        {
            _accountManager = accountManager;
            _orderService = orderService;
        }
        
        public IActionResult Index()
        {
            var customerOrders = _orderService.GetCustomerOrders(Convert.ToInt32(User.Claims.ElementAt(1).Value));
            var user = Convert.ToInt32(User.Claims.ElementAt(1).Value);
            var customer = _accountManager.GetCustomerById(user);
            var profile = new ProfileViewModel
            {
                Customer = customer,
                Orders = customerOrders
            };
            return View(profile);
        }
    }
}