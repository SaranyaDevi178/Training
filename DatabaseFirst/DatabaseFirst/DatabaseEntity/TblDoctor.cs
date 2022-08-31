using System;
using System.Collections.Generic;

namespace DatabaseFirst.DatabaseEntity
{
    public partial class TblDoctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; } = null!;
        public string? Gender { get; set; }
        public decimal? Salary { get; set; }
    }
}
