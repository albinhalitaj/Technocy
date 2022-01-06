using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; } 
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
        public string ShipName { get; set; }
        public string ShipSurname { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string OrderNotes { get; set; }
        public int Products { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}