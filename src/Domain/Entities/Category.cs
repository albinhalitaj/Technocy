using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public bool Status { get; set; } = true;
        public int ProductsCount { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        protected virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}