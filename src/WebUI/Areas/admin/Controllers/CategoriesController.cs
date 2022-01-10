using Application.admin;
using Application.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class CategoriesController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly INotyfService _notyf;

        public CategoriesController(CategoryManager categoryManager,
            INotyfService notyf)
        {
            _categoryManager = categoryManager;
            _notyf = notyf;
        }
        
        public IActionResult Index()
        {
            var categories = _categoryManager.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult New() => View();

        [HttpPost]
        public IActionResult New(InsertCategoryModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = _categoryManager.Add(model);
            if (result.Succeeded)
            {
                _notyf.Custom("Kategoria u shtua me sukses!", 5, "#FFBC53", "fa fa-check");
                return RedirectToAction(nameof(Index));
            }
            _notyf.Error("Diqka shkoi gabim! Ju lutem provoni përseri",5);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id > 0)
            {
                var category = _categoryManager.GetCategory(id);
                return category == null ? RedirectToAction(nameof(Index)) : View(category);
            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public IActionResult Edit(int id, InsertCategoryModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = _categoryManager.Update(id, model);
            if (result.Succeeded)
            {
                _notyf.Custom("Kategoria u editua me sukses!", 5, "#FFBC53", "fa fa-check");
                return RedirectToAction(nameof(Index)); 
            }
            _notyf.Error("Diqka shkoi gabim! Ju lutem provoni përseri",5);
            return View(model);
        }

        [HttpPost]
        [Route("admin/categories/delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = false;
            if (id > 0)
            {
                result = _categoryManager.Delete(id);
            }
            return Json(result);
        }
    }
}