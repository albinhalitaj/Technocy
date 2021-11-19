using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Password { get; set; }
    }
}