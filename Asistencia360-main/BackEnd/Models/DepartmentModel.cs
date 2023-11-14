namespace BackEnd.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }

        public int CompanyId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool Active { get; set; }
    }
}
