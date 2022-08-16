using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task DeleteAsync(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null);
        Task CreateRangeAsync(IEnumerable<Employee> employees);
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
        public bool CheckEmployeeEmail(string email);
        Task GetEmployeeDetailsAsync(int empId);
    }
}