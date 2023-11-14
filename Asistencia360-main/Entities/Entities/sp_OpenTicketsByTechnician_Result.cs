using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Keyless]
    public class sp_OpenTicketsByTechnician_Result
    {

        [Column("open_tickets")]
        public int OpenTickets { get; set; }

        [Column("technician")]
        public string Technician { get; set; }
    }
}
