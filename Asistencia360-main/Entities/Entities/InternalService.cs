using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class InternalService
    {
        public InternalService()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int InternalServiceId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
