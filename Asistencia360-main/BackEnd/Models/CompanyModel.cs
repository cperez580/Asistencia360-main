namespace BackEnd.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }
    }
}
