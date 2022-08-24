using EmployeeRecordBook.Core.Entities;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> CreateAsync(Department department);
        Task DeletedAsync(int departmentId);
        Task<Department> GetEmployeeAsync(int departmentID);
        Task<IEnumerable<Department>> GetEmployeesAsync();
        Task<Department> UpdatedAsync(int employeeId, Department department);
    }
}