using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly CustomerManager _customerManager;

        public CustomersController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        
        public IActionResult Index()
        {
            var customers = _customerManager.GetCustomers();
            return View(customers);
        }
    }
}