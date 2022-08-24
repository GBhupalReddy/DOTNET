using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRecordBook.Core.Entities
{
    [Table("Department", Schema = "Emp")]
    public class Department : EntitiesBase
    {
        public List<Employee> Employees { get; set; }
    }
}
