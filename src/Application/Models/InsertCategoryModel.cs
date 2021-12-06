using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class InsertCategoryModel
    {
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        [MinLength(4,ErrorMessage = "Ju lutem shënoni më shumë se 4 karaktere")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        [MaxLength(255,ErrorMessage = "Kjo fushë nuk mund të ketë më shumë se 255 karaktere")]
        public string Slug { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Ju lutem caktoni dukshmërinë e kategorisë")]
        public bool Visibility { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}