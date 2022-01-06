using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.admin.Models;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class DashboardController : Controller
    {
        private readonly DashboardManager _dashboardManager;

        public DashboardController(DashboardManager dashboardManager)
        {
            _dashboardManager = dashboardManager;
        }
        
        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                Konsumator = _dashboardManager.CustomerCount(),
                Orders = _dashboardManager.GetOrders(),
                Mesatarja = _dashboardManager.GetAverage(),
                Porosi = _dashboardManager.GetTotal(),
                Produkte = _dashboardManager.TotalProducts()
            };
            return View(model);
        }
    }
}