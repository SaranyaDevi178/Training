using System.ComponentModel.DataAnnotations;

namespace AppWep.Models
{
    public class Employee
    {

        [Key]
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
