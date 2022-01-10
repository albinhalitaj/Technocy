using System.Collections.Generic;
using Data.admin;
using Data.client;
using Domain.Entities;

namespace Application.client
{
    public class OrderService
    {
        private readonly OrderDal _orderDal;
        private readonly OrdersDal _adminOrderDal;

        public OrderService(OrderDal orderDal,OrdersDal adminOrderDal)
        {
            _orderDal = orderDal;
            _adminOrderDal = adminOrderDal;
        }

        public bool Insert(Order order, IEnumerable<OrderDetail> orderDetails)
        {
            return _orderDal.New(order, orderDetails);
        }

        public int GetLastOrderId() => _orderDal.GetLastOrderId();

        public IEnumerable<Order> GetCustomerOrders(int customerId) => _adminOrderDal.GetCustomerOrders(customerId);
    }
}