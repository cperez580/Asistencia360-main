using System.ComponentModel;

namespace FrontEnd.Models.UserModels
{
    public class RoleViewModel
    {
        public int role_id { get; set; }

        [DisplayName("Nombre")]
        public string title { get; set; } = null!;

        [DisplayName("Descripción")]
        public string description { get; set; } = null!;

        [DisplayName("Activo")]
        public bool active { get; set; }
    }
}
