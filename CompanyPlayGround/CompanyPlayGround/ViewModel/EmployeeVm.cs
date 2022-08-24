using CompanyPlayGround.Core.Entities;

namespace CompanyPlayGround.ViewModel
{
     public class EmployeeVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        
    }
}
