using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class PaymentModel
    {
        [Required(ErrorMessage = "required")]
        public string Cardholder { get; set; }
        
        [Required(ErrorMessage = "required")]
        [Display(Name = "Card Number")]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Expiration")]
        public string Expiration { get; set; }

        [Required(ErrorMessage = "required")]
        public string CVV { get; set; }
    }
}