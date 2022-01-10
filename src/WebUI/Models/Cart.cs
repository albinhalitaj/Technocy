using Domain.Entities;

namespace WebUI.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}