namespace Domain.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}