using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace WebUI.Models
{
    public class CheckoutModel
    {
        public Order Order { get; set; }
        
        [Required]
        public string Cardholder { get; set; }
        
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration Month")]
        public int Month { get; set; }

        [Required]
        [Display(Name = "Expiration Year")]
        public int Year { get; set; }

        [Required]
        public string CVC { get; set; }
        
        public long Amount { get; set; }
    }
}