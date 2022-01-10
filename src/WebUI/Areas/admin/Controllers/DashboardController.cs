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

        [HttpGet]
        public IActionResult GetChartData()
        {
            var data = _dashboardManager.GetChartData();
            var model = new
            {
                data.January,
                data.February,
                data.March,
                data.April,
                data.May,
                data.July,
                data.June,
                data.August,
                data.September,
                data.October,
                data.November,
                data.December
            };
            return Json(new {Data = model});
        }
    }
}