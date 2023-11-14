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
    public class sp_TicketsStatus_Result
    {
        [Column("@new_tickets")]
        public int NewTickets { get; set; }

        [Column("@open_tickets")]
        public int OpenTickets { get; set; }

        [Column("@reopened_tickets")]
        public int ReopenedTickets { get; set; }

        [Column("@nonclosed_tickets")]
        public int NonclosedTickets { get; set; }
        
        [Column("@closed_tickets")]
        public int ClosedTickets { get; set; }

        [Column("@total_tickets")]
        public int TotalTickets { get; set; }
        
        [Column("@sla_abouttoexpire")]
        public int slaAbouttoExpire { get; set; }
    }
}
