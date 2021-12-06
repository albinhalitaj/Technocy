namespace Domain.Entities
{
    public class ProductGallery
    {
        public int ProductGalleryId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string AltText { get; set; }
        
        public virtual Product Product { get; set; }
    }
}