using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Services = new HashSet<Service>();
            TicketCustomers = new HashSet<Ticket>();
            TicketTechnicians = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string IdNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Ticket> TicketCustomers { get; set; }
        public virtual ICollection<Ticket> TicketTechnicians { get; set; }
    }
}
