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
    public class sp_TicketsByCustomer_Result
    {

        [Column("tickets")]
        public int Tickets { get; set; }

        [Column("customer")]
        public string Customer { get; set; }
    }
}
