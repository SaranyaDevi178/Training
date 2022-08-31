using System.ComponentModel.DataAnnotations;

namespace Addingservices
{
    public class DemoClass
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
