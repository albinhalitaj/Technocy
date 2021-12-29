using System;
using System.Linq;
using Application.admin;
using Application.client;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly CategoryManager _categoryManager;
        private readonly WishlistManager _wishlistManager;

        public WishlistController(CategoryManager categoryManager,WishlistManager wishlistManager)
        {
            _categoryManager = categoryManager;
            _wishlistManager = wishlistManager;
        }
        
        // GET
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryManager.GetCategories().Where(x => x.Visibility);
            var wishlistItems = _wishlistManager.GetWishlistForCustomer(Convert.ToInt32(User.Claims.ElementAt(1).Value));
            return View(wishlistItems);
        }

        [HttpPost]
        public IActionResult Add(InsertWishlistModel model)
        {
            if (User.Identity is {IsAuthenticated: false})
            {
                return Json(new {Success = false, Error = "User is not authenticated"});
            }
            if (_wishlistManager.IsExist(model.ProductId))
            {
                return Json(new {Success = false});
            }
            var wishlistItem = new Wishlist
            {
                ProductId = model.ProductId,
                Price = model.Price,
                Stock = model.Stock,
                CustomerId = Convert.ToInt32(User.Claims.ElementAt(1).Value),
                InsertDate = DateTime.Now
            };
            
            var result = _wishlistManager.AddWishlistItem(wishlistItem);
            return Json(new {Success = result});
        }
    }
}