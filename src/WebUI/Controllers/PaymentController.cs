using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.client;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Helpers;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly OrderService _orderService;

        public PaymentController(OrderService orderService)
        {
            _orderService = orderService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProccessPayment(PaymentModel paymentModel)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            var checkoutModel = JsonConvert.DeserializeObject<CheckoutModel>(TempData["checkoutModel"].ToString() ?? string.Empty);
            var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(TempData["orderDetails"].ToString() ?? string.Empty);
            checkoutModel.Cardholder = paymentModel.Cardholder;
            checkoutModel.CardNumber = paymentModel.CardNumber;
            checkoutModel.Month = Convert.ToInt32(paymentModel.Expiration[..2]);
            checkoutModel.Year = Convert.ToInt32(paymentModel.Expiration.Split("/")[1]);
            var order = JsonConvert.DeserializeObject<Order>(TempData["order"].ToString() ?? string.Empty);
            checkoutModel.Order.Customer = order.Customer;
            checkoutModel.Amount = (int)cart.Sum(x => x.Product.Price * x.Quantity) + 5;

            var result = await ProcessPayment.PayAsync(checkoutModel);
            
            if (result == "Success")
            {
                order.PaymentStatus = PaymentStatus.Paid;
                order.Status = OrderStatus.Confirmed;
                var status = _orderService.Insert(order,orderDetails);
                if (!status) return RedirectToAction("Index");
                HttpContext.Session.SetObjectAsJson("cart",null);
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index");
        }
    }
}