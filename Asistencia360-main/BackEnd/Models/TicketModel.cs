namespace BackEnd.Models
{
    public class TicketModel
    {

        public int TicketId { get; set; }
        public int CustomerId { get; set; }
        public int? TechnicianId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Type { get; set; }
        public string? Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SolutionTime { get; set; }
        public string Status { get; set; } = null!;
        public string? Attachment { get; set; }
        public int? ServiceId { get; set; }
        public int? InternalServiceId { get; set; }
        public int? InventoryId { get; set; }
        public int? FaqId { get; set; }

    }
}
