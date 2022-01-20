using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
           
        [Route("/blog/smartfonet-me-te-mire-2022")]
        public IActionResult Index()
        {
            return View();
        }
    }
}