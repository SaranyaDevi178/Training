using System;
using System.Collections.Generic;

namespace DbFirstApproach.databaseentity
{
    public partial class Student
    {
        public int StudId { get; set; }
        public int? DepId { get; set; }
        public string? Name { get; set; }

        public virtual Department? Dep { get; set; }
    }
}
