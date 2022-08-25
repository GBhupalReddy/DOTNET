using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;

namespace CompanyPlayGround.Infrastructure.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<Employee> GetEmployeesAsync(int id);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}