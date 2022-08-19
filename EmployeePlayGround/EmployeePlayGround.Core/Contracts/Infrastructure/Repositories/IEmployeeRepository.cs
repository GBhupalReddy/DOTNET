using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task DeleteAsync(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null);
        Task CreateRangeAsync(IEnumerable<Employee> employees);
        Task<Employee> GetEmployeeAsync(int employeeId);
        //Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<Employee> UpdateAsync(int employeeId, Employee employee);
        public bool IsExitorNot(string? email = null, int? id = null);
        Task GetEmployeeDetailsAsync(int empId);
    }
}