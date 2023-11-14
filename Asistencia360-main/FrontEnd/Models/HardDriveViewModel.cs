using System.ComponentModel;

namespace FrontEnd.Models
{
    public class HardDriveViewModel
    {
        public int HardDriveId { get; set; }

        public int InventoryId { get; set; }
        public IEnumerable<InventoryViewModel> Inventories { get; set; }

        [DisplayName("Nombre")]
        public string Title { get; set; } = null!;

        [DisplayName("Tamaño")]
        public string Size { get; set; } = null!;
    }
}
