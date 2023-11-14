namespace BackEnd.Models
{
    public class HardDriveModel
    {
        public int HardDriveId { get; set; }

        public int InventoryId { get; set; }

        public string Title { get; set; } = null!;

        public string Size { get; set; } = null!;
    }
}
