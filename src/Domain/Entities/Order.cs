using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Ju lutem selektoni një metodë te pagesës!")]
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipName { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipSurname { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipAddress { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipCity { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipCountry { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipPostalCode { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
        public string ShipPhone { get; set; }
        [Required(ErrorMessage = "Kjo fushe është e domosdoshme")]
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