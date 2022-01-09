using System.Collections.Generic;
using System.Linq;
using Application.admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Helpers;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductManager _productManager;

        public CartController(ProductManager productManager)
        {
            _productManager = productManager;
        }
        
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            ViewBag.Cart = cart;
            if (cart == null) return View();
            foreach (var item in cart)
            {
                ViewBag.Total += item.Product.Price * item.Quantity;
            }
            return View();
        }

        [Route("/cart/cartdetails")]
        public IActionResult GetCartDetails()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            decimal total = 0;
            var count = 0;
            if (cart == null) return Json(new {Success = true, Items = count, Total = total.ToString("#,##0.00")});
            foreach (var item in cart)
            {
                total += item.Product.Price * item.Quantity; 
                count += item.Quantity;
            }
            return Json(new {Success = true,Items = count,Total = total.ToString("#,##0.00")});
            
        }
        
        public IActionResult Decrease(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            var product = IsExist(productId);
            if (product != -1)
            {
                if (cart[product].Quantity == 1)
                {
                    Remove(productId);
                    return RedirectToAction(nameof(Index));
                }
                cart[product].Quantity--;
            }
            HttpContext.Session.SetObjectAsJson("cart",cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("/cart/add/")]
        public IActionResult Add(int productId)
        {
            List<Cart> cart;
            decimal total = 0;
            int count = 0;
            if (HttpContext.Session.GetObjectFromJson<List<Cart>>("cart") == null)
            {
                cart = new List<Cart> {new() {Product = _productManager.GetProductById(productId),Quantity = 1}};
                HttpContext.Session.SetObjectAsJson("cart",cart);
                HttpContext.Session.SetInt32("count",cart.Count);
            }
            else
            {
                cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
                var index = IsExist(productId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Cart{Product = _productManager.GetProductById(productId),Quantity = 1});
                }
                HttpContext.Session.SetObjectAsJson("cart",cart);
                HttpContext.Session.SetInt32("count",cart.Count);
            }
            foreach (var item in cart)
            {
                total += item.Product.Price * item.Quantity;
                count += item.Quantity;
            }
            return Json(new {Success = true,Items = count,Total = total.ToString("#,##0.00")});
        }
        
        [Route("remove/{id:int}")]
        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            var index = IsExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObjectAsJson("cart", cart);
            HttpContext.Session.SetInt32("count",cart.Count);
            return RedirectToAction("Index");
        }

        private int IsExist(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<Cart>>("cart");
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [HttpGet]
        public IActionResult Clear()
        {
            HttpContext.Session.SetObjectAsJson("cart",null);
            return View("Index");
        }
    }
}