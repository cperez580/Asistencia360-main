using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? TicketId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string? Attachment { get; set; }

        public virtual Ticket? Ticket { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
    }
}
