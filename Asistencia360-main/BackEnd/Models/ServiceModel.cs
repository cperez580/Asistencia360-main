namespace BackEnd.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = null!;
        public int AdminId { get; set; }
        public string Type { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string ServiceSchedule { get; set; } = null!;
        public string SupportSchedule { get; set; } = null!;
        public double SlaOpen { get; set; }
        public double SlaClose { get; set; }
        public double OlaOpen { get; set; }
        public double OlaClose { get; set; }
        public bool Active { get; set; }
    }
}
