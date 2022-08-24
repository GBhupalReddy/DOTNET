using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRecordBook.Core.Entities
{
    [Table("Employee",Schema ="Emp")]
    public class Employee : EntitiesBase
    {
        [Column(Order=2)]
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
