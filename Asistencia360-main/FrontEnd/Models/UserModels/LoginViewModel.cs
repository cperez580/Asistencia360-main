using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models.UserModels
{
    public class LoginViewModel
    {
        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        public string email { get; set; } = null!;

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string password { get; set; } = null!;
    }
}
