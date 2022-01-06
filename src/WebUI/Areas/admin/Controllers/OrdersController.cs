using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
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
        [Route("admin/order/{orderNumber}")]
        public IActionResult Details(string orderNumber)
        {
            var order = _orderManager.GetOrderDetails(orderNumber);
            return View(order);
        }

        [HttpGet]
        public IActionResult Print(string orderNumber)
        {
            var order = _orderManager.GetOrderDetails(orderNumber);
            return new ViewAsPdf(order);
        }
    }
}