using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Models
{
    public class ProfileViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    } 
}