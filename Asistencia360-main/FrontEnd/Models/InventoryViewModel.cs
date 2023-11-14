using System.ComponentModel;

namespace FrontEnd.Models
{
    public class InventoryViewModel
    {
        public int InventoryId { get; set; }

        [DisplayName("Nombre")]
        public string Title { get; set; } = null!;

        [DisplayName("Sistema Operativo")]
        public string OperativeSystem { get; set; } = null!;

        [DisplayName("Versión")]
        public string Version { get; set; }

        [DisplayName("Tipo")]
        public string Type { get; set; } = null!;

        [DisplayName("Uso")]
        public string Purpose { get; set; } = null!;

        [DisplayName("IP Address")]
        public string IpAddress { get; set; } = null!;

        [DisplayName("Número de Activo")]
        public string AssetNumber { get; set; } = null!;

        [DisplayName("Número de Serie")]
        public string SerialNumber { get; set; } = null!;

        [DisplayName("Procesador")]
        public string Cpu { get; set; } = null!;

        [DisplayName("Core de CPU")]
        public int CpuCore { get; set; }

        [DisplayName("Memoria RAM")]
        public int Ram { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
