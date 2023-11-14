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
    public class sp_ServicesByCompany_Result
    {

        [Column("services")]
        public int Services { get; set; }

        [Column("company")]
        public string Company { get; set; }
    }
}
