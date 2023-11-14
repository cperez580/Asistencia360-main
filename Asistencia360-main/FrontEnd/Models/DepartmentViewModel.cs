using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [DisplayName("Empresa")]
        public int CompanyId { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres", MinimumLength = 4)]
        [DisplayName("Título")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres", MinimumLength = 4)]
        [DisplayName("Descripción")]
        public string Description { get; set; } = null!;

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
