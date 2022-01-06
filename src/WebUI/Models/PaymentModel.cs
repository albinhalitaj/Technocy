using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class PaymentModel
    {
        [Required]
        public string Cardholder { get; set; }
        
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration")]
        public string Expiration { get; set; }

        [Required]
        public string CVV { get; set; }
    }
}