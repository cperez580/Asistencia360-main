using System.ComponentModel;
using FrontEnd.Models.UserModels;

namespace FrontEnd.Models
{
    public class CommentViewModel
    {

        public int commentId { get; set; }
        public int ticketId { get; set; }
        public IEnumerable<TicketViewModel> Tickets { get; set; }
        public int? userId { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }

        [DisplayName("Mensaje")]
        public string message { get; set; } = null!;

        [DisplayName("Publicado")]
        public DateTime creationDate { get; set; }

        [DisplayName("Adjunto")]
        public string? attachment { get; set; }

    }
}
