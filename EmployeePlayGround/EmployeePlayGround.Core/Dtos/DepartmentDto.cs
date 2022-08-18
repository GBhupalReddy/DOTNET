using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Core.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
