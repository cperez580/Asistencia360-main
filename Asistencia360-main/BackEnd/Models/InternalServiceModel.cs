namespace BackEnd.Models
{
    public class InternalServiceModel
    {
        public int InternalServiceId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }
    }
}


