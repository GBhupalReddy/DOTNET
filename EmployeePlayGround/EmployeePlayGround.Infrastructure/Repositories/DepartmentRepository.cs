using EmployeePlayGround.Core.Contracts.Infrastructure.Repositories;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;

namespace EmployeePlayGround.Infrastructure.Repositories
{
    public class DepartmentRepository : IdepartmentRepository
    {
        public async Task CreateAsync(Department department)
        {
            // Not ideal way to use DB Context instance here, instead use constuctor injection. 
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Departments.Add(department);
                await employeeContext.SaveChangesAsync();
            }
        }
        public async Task CreateRangeAsync(IEnumerable<Department> departments)
        {
            // Not ideal way to use DB Context instance here, instead use constuctor injection. 
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Departments.AddRange(departments);
                await employeeContext.SaveChangesAsync();
            }
        }
    }
}
