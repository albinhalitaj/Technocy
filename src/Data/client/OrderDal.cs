using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.client
{
    public class OrderDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public OrderDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }
        
        public bool New(Order order,IEnumerable<OrderDetail> orderDetail)
        {
            const string sql = "usp_InsertOrder";
            const string insertOrderDetail = "usp_InsertOrderDetail";
            order.OrderNumber = GetNextOrderNumber();
            using var con = _dataAccessLayer.AppConn();
            using var tran = con.BeginTransaction();
            try
            {
                var values = new
                {
                    customerId = order.CustomerId,
                    orderNumber = order.OrderNumber,
                    orderDate = order.OrderDate,
                    paymentStatus = order.PaymentStatus,
                    status = order.Status,
                    shippedDate = order.ShippedDate,
                    shipName = order.ShipName,
                    shipSurname = order.ShipSurname,
                    shipAddress = order.ShipAddress,
                    shipCity = order.ShipCity,
                    shipCountry = order.ShipCountry,
                    shipPostalCode = order.ShipPostalCode,
                    shipPhone = order.ShipPhone,
                    subTotal = order.SubTotal,
                    total = order.Total,
                    paymentMethod = order.PaymentMethod,
                    orderNotes = order.OrderNotes
                };
                var result = con.Execute(sql, values, commandType: CommandType.StoredProcedure,transaction: tran);
                if (result == 1)
                {
                    foreach (var itemValues in orderDetail.Select(item => new
                    {
                        orderId = item.OrderId,
                        productId = item.ProductId,
                        price = item.Price,
                        quantity = item.Quantity,
                        discount = item.Discount
                    }))
                    {
                        con.Execute(insertOrderDetail, itemValues, commandType: CommandType.StoredProcedure,transaction: tran);
                    }
                }
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e);
                throw;
            }
            return true;
        }
        
        public IEnumerable<Order> GetCustomerOrders(string customerId)
        {
            throw new NotImplementedException();
        }

        private string GetNextOrderNumber()
        {
            const string function = "SELECT [dbo].[OrderNumber] ()";
            using var con = _dataAccessLayer.AppConn();
            var orderNumber = con.Query<string>(function, commandType: CommandType.Text).FirstOrDefault();
            return orderNumber;
        }

        public int GetLastOrderId()
        {
            const string sql = "usp_GetLastOrderId";
            using var con = _dataAccessLayer.AppConn();
            var orderId = con.Query<int>(sql, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return orderId;
        }
    }
}