using System;
using System.Collections.Generic;

namespace DatabaseFirst.DatabaseEntity
{
    public partial class Department
    {
        public string? DepName { get; set; }
        public int? Depid { get; set; }

        public virtual Student? Dep { get; set; }
    }
}
