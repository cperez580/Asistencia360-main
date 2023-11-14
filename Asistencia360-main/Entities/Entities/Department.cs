using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
