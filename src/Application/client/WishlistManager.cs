using System.Collections.Generic;
using System.Linq;
using Data.client;
using Domain.Entities;

namespace Application.client
{
    public class WishlistManager
    {
        private readonly WishlistDal _wishlistDal;
        private readonly admin.ProductManager _productManager;

        public WishlistManager(WishlistDal wishlistDal,admin.ProductManager productManager)
        {
            _wishlistDal = wishlistDal;
            _productManager = productManager;
        }

        public bool AddWishlistItem(Wishlist wishlistItem) => _wishlistDal.AddProduct(wishlistItem);

        public IEnumerable<Wishlist> GetWishlistForCustomer(int customerId)
        {
            var wishlistItems = _wishlistDal.GetWishlistForCustomer(customerId).ToList();
            
            foreach (var item in wishlistItems)
            {
                item.Product = _productManager.GetProductById(item.ProductId);
            }

            return wishlistItems;
        }

        public bool IsExist(int productId,int customerId) => _wishlistDal.IsExist(productId,customerId);

        public bool DeleteWishlistItem(int customerId, int productId) =>
            _wishlistDal.DeleteWishlistItem(customerId, productId);
    }
}