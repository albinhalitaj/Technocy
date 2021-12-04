using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public AccountController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            return View();
        }
    }
}