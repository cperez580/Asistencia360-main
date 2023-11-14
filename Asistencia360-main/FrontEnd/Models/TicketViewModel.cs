using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FrontEnd.Models.UserModels;

namespace FrontEnd.Models
{
    public class TicketViewModel
    {
        [DisplayName("Tiquete")]
        public int ticketId { get; set; }
        public int customerId { get; set; }
        public IEnumerable<UserViewModel> Customers { get; set; }
        public int? technicianId { get; set; }
        public IEnumerable<UserViewModel> Technicians { get; set; }


        [Required(ErrorMessage="Este campo es requerido")]
        [StringLength(120, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres.", MinimumLength = 4)]
        [DisplayName("Título")]
        public string? title { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(400, ErrorMessage = "La longitud debe ser de 4 a 120 caracteres.", MinimumLength = 4)]
        [DisplayName("Descripción")]
        public string? description { get; set; } = null!;

        [DisplayName("Prioridad")]
        public string? priority { get; set; }

        [DisplayName("Creado")]
        public DateTime StartDate { get; set; }

        [DisplayName("Cerrado")]
        public DateTime? end_date { get; set; }

        [DisplayName("Tiempo de Solución")]
        public int? solutionTime { get; set; }

        [DisplayName("Estado")]
        public string status { get; set; } = null!;

        [DisplayName("Adjunto")]
        public string? attachment { get; set; }


        public String? serviceId { get; set; }
        public IEnumerable<ServiceViewModel> Services { get; set; }
        public int? internalServiceId { get; set; }
        public IEnumerable<InternalServiceViewModel> InternalServices { get; set; }
        public int? inventoryId { get; set; }
        public IEnumerable<InventoryViewModel> InventoryList { get; set; }
        public int? faqId { get; set; }
        public IEnumerable<FAQViewModel> FAQList { get; set; }

        // Nuevas propiedades según la entidad Ticket
        [DisplayName("Tipo")]
        public string? Type { get; set; }


        /// lista de comentarios
        public List<CommentViewModel> Comments { get; set; }

    }
}
