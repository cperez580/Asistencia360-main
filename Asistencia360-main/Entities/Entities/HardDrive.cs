using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class HardDrive
    {
        public int HardDriveId { get; set; }
        public int InventoryId { get; set; }
        public string Title { get; set; } = null!;
        public string Size { get; set; } = null!;

        public virtual Inventory Inventory { get; set; } = null!;
    }
}
