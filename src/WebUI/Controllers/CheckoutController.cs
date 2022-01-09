using System;
using System.Collections.Generic;
using System.Linq;
using Application.client;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Helpers;
using WebUI.Models;
using AccountManager = Application.client.AccountManager;

namespace WebUI.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly AccountManager _accountManager;
        private readonly OrderService _orderService;

        public CheckoutController(AccountManager accountManager,
            OrderService orderService)
        {
            _accountManager = accountManager;
            _orderService = orderService;
        }
        
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<List<Cart>>("cart") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var customer = _accountManager.GetCustomerById(Convert.ToInt32(User.Claims.ElementAt(1).Value));
            ViewBag.Customer = customer;
            return View();
        }
        
        [HttpPost]
        public IActionResult ProcessOrder(CheckoutModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            if (ModelState.IsValid)
            {
               var order = new Order
                {
                Customer = _accountManager.GetCustomerById(Convert.ToInt32(User.Claims.ElementAt(1).Value)),
                OrderDate = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Unpaid,
                PaymentMethod = model.Order.PaymentMethod,
                Status = (int) OrderStatus.ManualVerificationNeeded,
                SubTotal = cart.Sum(x=>x.Product.Price * x.Quantity),
                Total = cart.Sum(x=>x.Product.Price * x.Quantity) + 5,
                ShipName = model.Order.ShipName,
                ShipSurname = model.Order.ShipSurname,
                ShipAddress = model.Order.ShipAddress,
                ShipCity = model.Order.ShipCity,
                ShipCountry = model.Order.ShipCountry,
                ShipPostalCode = model.Order.ShipPostalCode,
                ShipPhone = model.Order.ShipPhone,
                OrderNotes = model.Order.OrderNotes,
                CustomerId = Convert.ToInt32(User.Claims.ElementAt(1).Value)
                };

            var orderDetails = 
                cart.Select(cartItem =>
                    new OrderDetail {OrderId = _orderService.GetLastOrderId() + 1, 
                        ProductId = cartItem.Product.ProductId, 
                        Price = cartItem.Product.Price, 
                        Quantity = cartItem.Quantity}).ToList();

            if (model.Order.PaymentMethod == PaymentMethod.Card)
            {
                TempData["checkoutModel"] = JsonConvert.SerializeObject(model);
                TempData["order"] = JsonConvert.SerializeObject(order);
                TempData["orderDetails"] = JsonConvert.SerializeObject(orderDetails);
                return RedirectToAction("Index", "Payment");
            }
            
            var result = _orderService.Insert(order,orderDetails);
            if (result)
            {
                HttpContext.Session.SetObjectAsJson("cart",null);
            }
            return RedirectToAction(nameof(Confirmation)); 
            }

            return View("Index",model);
        }

        [HttpGet]
        [Route("/order/confirmation")]
        public IActionResult Confirmation(string orderNumber) => View();
    }
}