using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class FAQViewModel
    {
        public int FaqId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres", MinimumLength = 4)]
        [DisplayName("Título")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(360, ErrorMessage = "La longitud debe ser de 4 a 360 caracteres", MinimumLength = 4)]
        [DisplayName("Síntoma")]
        public string Symptom { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(360, ErrorMessage = "La longitud debe ser de 4 a 360 caracteres", MinimumLength = 4)]
        [DisplayName("Problema")]
        public string Problem { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(360, ErrorMessage = "La longitud debe ser de 4 a 360 caracteres", MinimumLength = 4)]
        [DisplayName("Solución")]
        public string Solution { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(360, ErrorMessage = "La longitud debe ser de 4 a 360 caracteres", MinimumLength = 4)]
        [DisplayName("Notas")]
        public string? Notes { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
