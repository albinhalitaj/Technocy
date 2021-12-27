using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class DashboardController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}