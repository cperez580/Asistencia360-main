namespace BackEnd.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int? TicketId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string? Attachment { get; set; }
    }
}

