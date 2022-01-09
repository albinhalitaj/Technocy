using Application.admin;
using Application.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotyfService _notyf;
        private readonly AccountManager _accountManager;

        public ProductsController(ProductManager productManager,
            CategoryManager categoryManager,
            IWebHostEnvironment webHostEnvironment,
            INotyfService notyf,
            AccountManager accountManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
            _accountManager = accountManager;
        }
        
        // GET
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Categories = _categoryManager.GetCategories(),
                Products = _productManager.GetProducts()
            };
            return View("~/Areas/admin/Views/Products/Index.cshtml",model);
        }

        [HttpGet]
        public IActionResult New()
        {
            var categories = _categoryManager.GetCategories();
            var model = new InsertProductModel
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult New(InsertProductModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productManager.Add(model,model.ProductCategories,_webHostEnvironment.WebRootPath);
                if (result)
                {
                    _notyf.Custom("Produkti u shtua me sukses!", 5, "#FFBC53", "fa fa-check");
                    return RedirectToAction(nameof(Index));
                }
                _notyf.Error("Diqka shkoi gabim! Ju lutem provoni përseri",5);
            }
            model.Categories = _categoryManager.GetCategories();
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var product = _productManager.FirstOrDefault(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(EditProductModel model,int id)
        {
            if (!ModelState.IsValid && id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            model.ProductId = id;
            var result = _productManager.Edit(model,model.ProductCategories, _webHostEnvironment.WebRootPath);
            if (result)
            {
                _notyf.Custom("Produkti u modifikua me sukses!", 5, "#FFBC53", "fa fa-check");
                return RedirectToAction(nameof(Index)); 
            }
            _notyf.Error("Diqka shkoi gabim! Ju lutem provoni përseri",5); 
            return View(nameof(Index));
        }

        public IActionResult Filtro(string startingPrice,string endingPrice,bool visibility,string[] categories)
        {
            ProductFilterModel model = null;
            if (!string.IsNullOrEmpty(startingPrice) && !string.IsNullOrEmpty(endingPrice))
            {
                model = new ProductFilterModel
                {
                    StartingPrice = decimal.Parse(startingPrice),
                    EndingPrice = decimal.Parse(endingPrice),
                    Categories = categories,
                    Visibility = visibility
                };
            }
            
            var filteredProducts = _productManager.Filtro(model);
            var productsModel = new ProductListViewModel
            {
                Categories = _categoryManager.GetCategories(),
                Products = filteredProducts
            };

            return View("~/Areas/admin/Views/Products/Index.cshtml", productsModel);
        }

        [Route("/admin/products/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = false;
            if (id > 0)
            {
                result = _productManager.Remove(id, _webHostEnvironment.WebRootPath);
            }
            return Json(result);
        }

        [Route("/admin/products/deleteimage/{id}/{name}")]
        [HttpPost]
        public IActionResult DeleteImage(int id, string name)
        {
            if (id <= 0 && string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(Edit), new {id});
            }
            var result = _productManager.RemoveProductImages(name, id, _webHostEnvironment.WebRootPath);
            var model = new DeleteImageResult();
            if (result)
            {
                model.Success = result;
                return Json(model); 
            }
            model.Success = false;
            model.Error = "Produkti duhet të ketë së paku një foto!";
            return Json(model);
        }

        [HttpPost]
        [Route("/admin/products/confirmpass/{username}/{pass}")]
        public IActionResult ConfirmPass(string username,string pass)
        {
            if (pass == null || username == null)
            {
                return null;
            }

            var result = _accountManager.Login(username,pass);
            return result == null ? Json(false) : Json(true);
        }

        private class DeleteImageResult
        {
            public bool Success { get; set; }
            public string Error { get; set; }
        }
    }
}