using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public ProfileController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        
        // GET
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x=>x.Visibility);
            return View();
        }
    }
}