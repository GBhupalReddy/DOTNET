using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeePlayGround.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeesAsync(int pageIndex,int pageSize,string sortField, string sortOrder="asc", string filterText=null)
        {
            if(sortOrder=="dse")
            {
                IEnumerable<EmployeeDto> employeeQuery=null;
                switch (sortField)
                {
                    case "Id":
                         employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(e => e.Id)
                                            select new EmployeeDto
                                            {
                                                Id = employee.Id,
                                                Name = employee.Name,
                                                Salary = employee.Salary,
                                                Email= employee.Email,
                                                DepartmentName = employee.Department.Name
                                            };
                        break;
                    case "Name":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(e => e.Name)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                    case "Salary":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(e => e.Salary)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                    case "Email":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderByDescending(e => e.Email)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                }
                 
                return employeeQuery.Skip((pageIndex-1)*pageSize).Take(pageSize);
            }
            else
            {
                IEnumerable<EmployeeDto> employeeQuery = null;
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(e => e.Id)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                    case "Name":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(e => e.Name)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                    case "Salary":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(e => e.Salary)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                    case "Email":
                        employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department).OrderBy(e => e.Email)
                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        };
                        break;
                }

                return employeeQuery.Skip((pageIndex-1)*pageSize).Take(pageSize);
                
            }
        }
        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            // Not ideal way to use DB Context instance here, instead use constuctor injection. 
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Employees.AddRange(employees);
                await employeeContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employeeQuery = from employee in _employeeContext.Employees.Include(e => e.Department)
                                select new EmployeeDto
                                {
                                    Id = employee.Id,
                                    Name = employee.Name,
                                    Salary = employee.Salary,
                                    DepartmentName = employee.Department.Name
                                };
            //return await _employeeContext.Employees.ToListAsync();
            return await employeeQuery.ToListAsync();  // Executes DB Query in DB and Get results.
        }
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await _employeeContext.Employees.FindAsync(employeeId);
        }
        public async Task<Employee> UpdateAsync(int employeeId, Employee employee)
        {
            var employeeToBeUpdated = await GetEmployeeAsync(employeeId);
            employeeToBeUpdated.Name = employee.Name;
            employeeToBeUpdated.Email = employee.Email;
            employeeToBeUpdated.Salary = employee.Salary;
            employeeToBeUpdated.DepartmentId = employee.DepartmentId;
            _employeeContext.Employees.Update(employeeToBeUpdated);
            _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
            return employeeToBeUpdated;
        }
        public async Task DeleteAsync(int employeeId)
        {
            var employeeToBeDeleted = await GetEmployeeAsync(employeeId);
            _employeeContext.Employees.Remove(employeeToBeDeleted);
            await _employeeContext.SaveChangesAsync();
        }
    }
}
