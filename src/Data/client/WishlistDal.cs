using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.client
{
    public class WishlistDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public WishlistDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public bool AddProduct(Wishlist wishlistItem)
        {
            const string sql = "usp_InsertWishlistItem";
            using var con = _dataAccessLayer.AppConn();
            var values = new
            {
                customerId = wishlistItem.CustomerId,
                productId = wishlistItem.ProductId,
                price = wishlistItem.Price,
                stock = wishlistItem.Stock,
                addedOn = wishlistItem.InsertDate
            };
            var rowsAffected = con.ExecuteAsync(sql, values, commandType: CommandType.StoredProcedure).Result;
            return rowsAffected == 1;
        }

        public IEnumerable<Wishlist> GetWishlistForCustomer(int customerId)
        {
            const string sql = "usp_GetWishlistForCustomer";
            using var con = _dataAccessLayer.AppConn();
            var wishlistItems =
                con.QueryAsync<Wishlist>(sql, new {customerId}, commandType: CommandType.StoredProcedure).Result.ToList();
            return wishlistItems;
        }

        public bool IsExist(int productId)
        {
            const string sql = "usp_IsProductInWishlist";
            using var con = _dataAccessLayer.AppConn();
            var result = con.QueryAsync<Wishlist>(sql, new {productId}, commandType: CommandType.StoredProcedure).Result;
            return result.Any();
        }
    }
}