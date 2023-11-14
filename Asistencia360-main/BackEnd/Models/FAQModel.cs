namespace BackEnd.Models
{
    public class FAQModel
    {
        public int FaqId { get; set; }
        public string Title { get; set; } = null!;
        public string Symptom { get; set; } = null!;
        public string Problem { get; set; } = null!;
        public string Solution { get; set; } = null!;
        public string? Notes { get; set; }
        public bool Active { get; set; }
    }
}
