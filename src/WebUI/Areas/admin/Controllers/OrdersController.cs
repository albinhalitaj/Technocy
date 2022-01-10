using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class OrdersController : Controller
    {
        private readonly OrderManager _orderManager;

        public OrdersController(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        
        public IActionResult Index()
        {
            var orders = _orderManager.GetOrders();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Details(string orderNumber)
        {
            var order = _orderManager.GetOrderDetails(orderNumber);
            return View(order);
        }

        [HttpGet]
        public IActionResult Print(string orderNumber)
        {
            var order = _orderManager.GetOrderDetails(orderNumber);
            return View(order);
        }

        [HttpPost]
        public IActionResult ChangeOrderStatus(string orderNumber,int orderStatus)
        {
            var result = _orderManager.UpdateOrderStatus(orderNumber, orderStatus);
            return Json(result);
        }
    }
}