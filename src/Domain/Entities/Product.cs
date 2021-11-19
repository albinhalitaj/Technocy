using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
            ProductGalleries = new HashSet<ProductGallery>();
        }
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public bool Status { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductGallery> ProductGalleries { get; set; }
    }
}