using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class Company
    {
        public Company()
        {
            Departments = new HashSet<Department>();
        }

        public int CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
