using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models.UserModels
{
    public class ForgotPasswordViewModel
    {
        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        public string email { get; set; } = null!;
    }
}
