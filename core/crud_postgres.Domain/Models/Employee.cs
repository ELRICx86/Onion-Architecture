using System.ComponentModel.DataAnnotations;

namespace crud_postgresql.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Department { get; set; }
        public required int Salary { get; set; }
    }
}
