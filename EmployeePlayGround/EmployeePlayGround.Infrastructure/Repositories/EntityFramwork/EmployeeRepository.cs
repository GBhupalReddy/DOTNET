using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeePlayGround.Infrastructure.Repositories.EntityFramwork
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

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await (from employee in _employeeContext.Employees.Include(e => e.Department)

                          select new EmployeeDto
                          {
                              Id = employee.Id,
                              Name = employee.Name,
                              Salary = employee.Salary,
                              Email = employee.Email,
                              DepartmentName = employee.Department.Name
                          }).ToListAsync();

        }

        //Display the employees in order by
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null)
        {
            var employeesQuery = await (from employee in _employeeContext.Employees.Include(e => e.Department).Where(emp => emp.Name.ToLower().Contains(filterText)
                       || emp.Email.ToLower().Contains(filterText) || filterText.Equals(null))

                                        select new EmployeeDto
                                        {
                                            Id = employee.Id,
                                            Name = employee.Name,
                                            Salary = employee.Salary,
                                            Email = employee.Email,
                                            DepartmentName = employee.Department.Name
                                        }).ToListAsync();
            if (sortOrder == "desc")
            {
                IEnumerable<EmployeeDto> employeeQuery = new List<EmployeeDto>();
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = employeesQuery.OrderByDescending(emp => emp.Id);

                        break;
                    case "Name":
                        employeeQuery = employeesQuery.OrderByDescending(emp => emp.Name);
                        break;
                    case "Salary":
                        employeeQuery = employeesQuery.OrderByDescending(emp => emp.Salary);
                        break;
                    case "Email":
                        employeeQuery = employeesQuery.OrderByDescending(emp => emp.Email);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                return employeeQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                IEnumerable<EmployeeDto> employeeQuery = new List<EmployeeDto>();
                switch (sortField)
                {
                    case "Id":
                        employeeQuery = employeesQuery.OrderBy(emp => emp.Id);
                        break;
                    case "Name":
                        employeeQuery = employeesQuery.OrderBy(emp => emp.Name);
                        break;
                    case "Salary":
                        employeeQuery = employeesQuery.OrderBy(emp => emp.Salary);
                        break;
                    case "Email":
                        employeeQuery = employeesQuery.OrderBy((emp) => emp.Email);
                        break;
                    default: throw new ArgumentOutOfRangeException();


                }

                return employeeQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            }
        }

        // Create new employee 
        public async Task CreateRangeAsync(IEnumerable<Employee> employees)
        {
            // Not ideal way to use DB Context instance here, instead use constuctor injection. 
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Employees.AddRange(employees);
                await employeeContext.SaveChangesAsync();
            }
        }

        public async Task GetEmployeeDetailsAsync(int empId)
        {
            var employeeDeatails = await (from emp in _employeeContext.Employees.Where(e => e.Id.Equals(empId))
                                          select emp).ToListAsync();
            if (employeeDeatails.Any())
            {
                foreach (var emp in employeeDeatails)
                {
                    Console.WriteLine($"{emp.Id} {emp.Name} {emp.Email} {emp.Salary} {emp.DepartmentId}");
                }
            }
            else
            {
                Console.WriteLine($"Data not found for this employeeId{empId}");
            }


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

        public bool IsExitorNot(string? email = null, int? id = null)
        {
            var result = from department in _employeeContext.Employees.Where(d => d.Email.Equals(email) || d.Id.Equals(id))
                         select department;
            if (result.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
