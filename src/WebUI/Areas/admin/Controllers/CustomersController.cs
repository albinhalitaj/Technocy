using System.Linq;
using Application.admin;
using Application.client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class CustomersController : Controller
    {
        private readonly CustomerManager _customerManager;
        private readonly OrderService _orderService;

        public CustomersController(CustomerManager customerManager,OrderService orderService)
        {
            _customerManager = customerManager;
            _orderService = orderService;
        }
        
        public IActionResult Index()
        {
            var customers = _customerManager.GetCustomers();
            return View(customers);
        }

        [HttpGet]
        [Route("/admin/customer/{customerId:int}")]
        public IActionResult Details(int customerId)
        {
            var customer = _customerManager.GetCustomer(customerId);
            if (customer == null) return RedirectToAction(nameof(Index));
            customer.Orders = _orderService.GetCustomerOrders(customerId).ToList();
            ViewBag.CustomerMetaData = _customerManager.LastOrderHrs(customerId);
            return View(customer);
        }
    }
}