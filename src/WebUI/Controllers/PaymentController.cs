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
            /*if (HttpContext.Session.GetObjectFromJson<List<Cart>>("cart") == null)
            {
                return RedirectToAction("Index", "Cart");
            }*/
            return View();
        }

        public async Task<IActionResult> ProccessPayment(PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
                var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(TempData["orderDetails"].ToString() ?? string.Empty);
                var order = JsonConvert.DeserializeObject<Order>(TempData["order"].ToString() ?? string.Empty);
                var model = new CheckoutModel
                {
                    Amount = (int)cart.Sum(x => x.Product.Price * x.Quantity) + 5,
                    Order = order,
                    PaymentModel = paymentModel

                };

                var result = await ProcessPayment.PayAsync(model);
            
                if (result == "Success")
                {
                    order.PaymentStatus = PaymentStatus.Paid;
                    order.Status = OrderStatus.Confirmed;
                    var status = _orderService.Insert(order,orderDetails);
                    if (!status) return RedirectToAction("Index");
                    HttpContext.Session.SetObjectAsJson("cart",null);
                    return RedirectToAction("Confirmation","Checkout");
                }     
            }
            return View("Index",paymentModel);
        }
    }
}