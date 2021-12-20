using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Fusha Email-it duhet plotësuar")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fusha Fjalëkalimi-it duhet plotësuar")]
        public string Fjalekalimi { get; set; }
        [Required(ErrorMessage = "Fusha Konfirmo Fjalëkalimi-it duhet plotësuar")]
        [Compare("Fjalekalimi",ErrorMessage = "Fjalëkalimi nuk përputhet")]
        public string KonfirmoFjalekalimin { get; set; }
        [Required(ErrorMessage = "Fusha Emri duhet plotësuar")]
        [MinLength(2,ErrorMessage = "Emri duhet të jetë më i gjatë se 2 karaktere")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Fusha Mbiemri duhet plotësuar")]
        public string Mbiemri { get; set; }
        [Required(ErrorMessage = "Fusha Gjinia duhet plotësuar")]
        public string Gjinia { get; set; }
        [Required(ErrorMessage = "Fusha Shteti duhet plotësuar")]
        public string Shteti { get; set; }
        [Required(ErrorMessage = "Fusha Qyteti duhet plotësuar")]
        public string Qyteti { get; set; }
        [Required(ErrorMessage = "Fusha Dita e lindjes duhet plotësuar")]
        public int DitaLindjes { get; set; }
        [Required(ErrorMessage = "Fusha Muaji i lindjes duhet plotësuar")]
        public int MuajiLindjes { get; set; }
        [Required(ErrorMessage = "Fusha Viti Lindjes duhet plotësuar")]
        public int VitiLindjes { get; set; }
    }
}