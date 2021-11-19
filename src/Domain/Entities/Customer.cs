using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            WishlistItems = new HashSet<Wishlist>();
        }
        
        public Guid CusomterId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Wishlist> WishlistItems { get; set; }
    }
}