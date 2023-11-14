using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Faq
    {
        public Faq()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int FaqId { get; set; }
        public string Title { get; set; } = null!;
        public string Symptom { get; set; } = null!;
        public string Problem { get; set; } = null!;
        public string Solution { get; set; } = null!;
        public string? Notes { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
