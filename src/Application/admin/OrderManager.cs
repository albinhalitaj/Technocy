using System.Collections.Generic;
using Data.admin;
using Domain.Entities;

namespace Application.admin
{
    public class OrderManager
    {
        private readonly OrdersDal _ordersDal;

        public OrderManager(OrdersDal ordersDal)
        {
            _ordersDal = ordersDal;
        }

        public IEnumerable<Order> GetOrders() => _ordersDal.GetOrders();

        public Order GetOrderDetails(string orderNumber) => _ordersDal.GetOrderDetails(orderNumber);
    }
}