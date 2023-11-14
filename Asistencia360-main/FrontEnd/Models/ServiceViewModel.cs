using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FrontEnd.Models.UserModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FrontEnd.Models
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres", MinimumLength = 4)]
        [DisplayName("Nombre")]
        public string Title { get; set; } = null!;

        public int AdminId { get; set; }

        [BindNever]
        public IEnumerable<UserViewModel> Users { get; set; }

        public string Type { get; set; } = null!;


        public string Priority { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud debe ser de 4 a 50 caracteres", MinimumLength = 4)]
        [DisplayName("Horario de Servicio")]
        public string ServiceSchedule { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres", MinimumLength = 4)]
        [DisplayName("Horario de Soporte")]
        public string SupportSchedule { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 9999999999, ErrorMessage = "La longitud debe ser de 1 a 64 caracteres")]
        [DisplayName("SLA Apertura")]
        public double SlaOpen { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 9999999999, ErrorMessage = "La longitud debe ser de 1 a 64 caracteres")]
        [DisplayName("SLA Cierre")]
        public double SlaClose { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 9999999999, ErrorMessage = "La longitud debe ser de 1 a 64 caracteres")]
        [DisplayName("OLA Apertura")]
        public double OlaOpen { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, 9999999999, ErrorMessage = "La longitud debe ser de 1 a 64 caracteres")]
        [DisplayName("OLA Cierre")]
        public double OlaClose { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
        
        //
        // Variables For Front End
        //

        public string NameType => Title + " - " + Type;
    }
}
