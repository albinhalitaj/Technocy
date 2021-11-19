using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        // GET
        public IActionResult Login()
        {
            return View();
        }

    }
}