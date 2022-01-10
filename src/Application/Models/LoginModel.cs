using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Fusha Emaili duhet plotësuar")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fusha Fjalekalimi duhet plotësuar")]
        public string Fjalekalimi { get; set; }
    }
}