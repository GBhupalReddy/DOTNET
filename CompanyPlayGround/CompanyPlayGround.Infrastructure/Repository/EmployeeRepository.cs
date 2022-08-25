using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;
using CompanyPlayGround.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlayGround.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompenyContext _compenyContext;
        public EmployeeRepository(CompenyContext compenyContext)
        {
            _compenyContext = compenyContext;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await (from employee in _compenyContext.Employees.Include(e => e.Department)

                          select new EmployeeDto
                          {
                              Id = employee.Id,
                              Name = employee.Name,
                              Salary = employee.Salary,
                              Email = employee.Email,
                              DepartmentName = employee.Department.Name
                          }).ToListAsync();

        }
        public async Task<Employee> GetEmployeesAsync(int id)
        {
            return await _compenyContext.Employees.FindAsync(id);

        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            _compenyContext.Employees.Add(employee);
            await _compenyContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id,Employee employee)
        {
            var emp=await GetEmployeesAsync(id);
            emp.Name=employee.Name;
            emp.Email=employee.Email;
            emp.Salary=employee.Salary;
            emp.DepartmentId=employee.DepartmentId;

            _compenyContext.Employees.Update(emp);
           await _compenyContext.SaveChangesAsync();

            return emp;

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee=await GetEmployeesAsync(id);
            _compenyContext.Employees.Remove(employee);
            await _compenyContext.SaveChangesAsync();
        }

    }
}
