using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models.UserModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; } = null!;

        [DisplayName("Apellidos")]
        public string LastName { get; set; } = null!;

        [DisplayName("Cédula")]
        public int IdNumber { get; set; }

        [DisplayName("Correo Electrónico")]
        public string Email { get; set; } = null!;

        [DisplayName("Contraseña")]
        public string Password { get; set; } = null!;

        [DisplayName("Empresa")]
        [Required(ErrorMessage = "La empresa es requerida")]
        public int CompanyId { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "El departamento es requerida")]
        public int DepartmentId { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }

        public int RoleId { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }

        //
        // Variables for Front End
        //

        public string FullName => Name + " " + LastName;
    }
}
