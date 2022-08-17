using EmployeePlayGround.Core.Contracts.Infrastructure.Repositories;
using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;
using EmployeePlayGround.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeePlayGround.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _employeeContext;
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
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
        public async Task<Department> GetDepartmentAsync(int deptId)
        {
            return await _employeeContext.Departments.FindAsync(deptId);
        }
        public async Task<Department> UpdateAsync(int employeeId, Department department)
        {
            var departmentToBeUpdate = await GetDepartmentAsync(employeeId);
            departmentToBeUpdate.Name = department.Name;
            _employeeContext.Departments.Update(departmentToBeUpdate);
            _employeeContext.SaveChanges();  // Actual execution of the command happens here with DB.
            return departmentToBeUpdate;
        }
        public async Task GetDepartmetDeatilsAsync(int deapertmentId)
        {
            var department = from dept in _employeeContext.Departments.Where(d => d.Id == deapertmentId)
                             select dept;
            if (department.Any())
            {
                foreach (var dept in department)
                {
                    Console.WriteLine($"{dept.Id}  {dept.Name}");
                }
            }
            else
            {
                Console.WriteLine($"Data not found for this departmentId {deapertmentId}");
            }

        }

        public bool CheckDepatment(string depatmentName)
        {
            var result = from department in _employeeContext.Departments.Where(d => d.Name.Equals(depatmentName))
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
        public async Task<IEnumerable<Department>> GetDepartmentsAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null)
        {
            IEnumerable<Department>? departmentQuery = null;
            if (sortOrder == "des")
            {
                
                switch (sortField)
                {
                    case "Id":
                        departmentQuery = (from department in _employeeContext.Departments.Where(e => filterText == null || e.Name.ToLower().Contains(filterText)).OrderByDescending(e => e.Id)
                                           select new Department
                                           {
                                               Id = department.Id,
                                               Name = department.Name,

                                           });

                        break;
                    case "Name":
                        departmentQuery = (from department in _employeeContext.Departments.Where(e => filterText == null || e.Name.ToLower().Contains(filterText)).OrderByDescending(e => e.Name)
                                           select new Department
                                           {
                                               Id = department.Id,
                                               Name = department.Name,

                                           });
                        break;
                }
                return departmentQuery;
            }
            else
            {
                switch (sortField)
                {
                    case "Id":
                        departmentQuery = (from department in _employeeContext.Departments.Where(e => filterText==null || e.Name.ToLower().Contains(filterText)).OrderBy(e => e.Id)
                                           select new Department
                                           {
                                               Id = department.Id,
                                               Name = department.Name,

                                           });

                        break;
                    case "Name":
                        departmentQuery = (from department in _employeeContext.Departments.Where(e => filterText == null || e.Name.ToLower().Contains(filterText)).OrderBy(e => e.Name)
                                           select new Department
                                           {
                                               Id = department.Id,
                                               Name = department.Name,

                                           });
                        break;
                }
                return departmentQuery;
            }
        }
    }
}
