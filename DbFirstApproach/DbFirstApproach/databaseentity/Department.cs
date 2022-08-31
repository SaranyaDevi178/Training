using System;
using System.Collections.Generic;

namespace DbFirstApproach.databaseentity
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int Depid { get; set; }
        public string? Depname { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
