using System;

namespace Domain.Entities
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool Stock { get; set; }
        public DateTime InsertDate { get; set; }
        
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        
    }
}