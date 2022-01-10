using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class OrdersDal
    {
        private readonly DataAccessLayer _dataAccessLayer;
        private readonly client.AccountDal _accountDal;
        private readonly ProductDal _productDal;

        public OrdersDal(DataAccessLayer dataAccessLayer,client.AccountDal accountDal,ProductDal productDal)
        {
            _dataAccessLayer = dataAccessLayer;
            _accountDal = accountDal;
            _productDal = productDal;
        }

        public IEnumerable<Order> GetOrders()
        {
            const string sql = "usp_GetOrders";
            using var con = _dataAccessLayer.AppConn();
            var orders = con.Query<Order>(sql, commandType: CommandType.StoredProcedure).ToList();
            foreach (var order in orders)
            {
                order.Products = GetOrderDetails(order.OrderId).Count();
            }
            return orders;
        }

        private IEnumerable<OrderDetail> GetOrderDetails(int orderId)
        {
            const string sql = "usp_GetOrderDetails";
            using var con = _dataAccessLayer.AppConn();
            var orderDetails = con.Query<OrderDetail>(sql, new{orderId}, commandType: CommandType.StoredProcedure).ToList();
            foreach (var item in orderDetails)
            {
                var product = _productDal.GetProduct(item.ProductId);
                product.ProductGalleries = _productDal.GetProductGalleries(product.ProductId).ToList();
                item.Product = product;
            }
            return orderDetails;
        }

        public IEnumerable<Order> GetCustomerOrders(int customerId)
        {
            const string sql = "usp_GetCustomerOrders";
            using var con = _dataAccessLayer.AppConn();
            var customerOrders = con.Query<Order>(sql, new {customerId}, commandType: CommandType.StoredProcedure).ToList();
            foreach (var order in customerOrders)
            {
                order.OrderDetails = GetOrderDetails(order.OrderId);
            }
            return customerOrders;
        }

        public Order GetOrderDetails(string orderNumber)
        {
            const string sql = "usp_GetFullOrderDetails";
            using var con = _dataAccessLayer.AppConn();
            var order = con.Query<Order>(sql, new {orderNumber}, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (order != null)
            {
                order.OrderDetails = GetOrderDetails(order.OrderId);
                order.Products = GetOrderDetails(order.OrderId).Count();
                order.Customer = _accountDal.GetCustomer(order.CustomerId);
            }
            return order;
        }

        public bool ChangeOrderStatus(string orderNumber,int orderStatus)
        {
            const string sql = "usp_UpdateOrderStatus";
            using var con = _dataAccessLayer.AppConn();
            var status = con.Execute(sql, new {orderNumber,orderStatus}, commandType: CommandType.StoredProcedure);
            return status > 0;
        }
    }
}