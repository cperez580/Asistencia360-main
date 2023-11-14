using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            HardDrives = new HashSet<HardDrive>();
            Tickets = new HashSet<Ticket>();
        }

        public int InventoryId { get; set; }
        public string Title { get; set; } = null!;
        public string OperativeSystem { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Purpose { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public string AssetNumber { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string Cpu { get; set; } = null!;
        public int CpuCore { get; set; }
        public int Ram { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<HardDrive> HardDrives { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
