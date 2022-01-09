using Domain.Entities;

namespace WebUI.Models
{
    public class CheckoutModel
    {
        public Order Order { get; set; }
        
        public PaymentModel PaymentModel { get; set; } 
        public long Amount { get; set; }
    }
}