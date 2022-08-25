using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordBook.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //public void Create(Department department)
        //{
        // Not ideal Way use DB Context instance here, instead use constructor injection
        //using (var employeeContext = new EmployeeContext())
        //{
        //    employeeContext.Departments.Add(department);
        //    employeeContext.SaveChanges();
        //}
        private readonly EmployeeContext _employeeContext;
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<Department> CreateAsync(Department department)
        {

            _employeeContext.Departments.Add(department);
            await _employeeContext.SaveChangesAsync();
            return department;

        }
        public async Task<IEnumerable<Department>> GetEmployeesAsync()
        {
            var departmentQuery = from department in _employeeContext.Departments
                                  select department;
            return await departmentQuery.ToListAsync();
        }

        public async Task<Department> GetEmployeeAsync(int departmentID)
        {
            return await _employeeContext.Departments.Where(e => e.Id == departmentID).FirstOrDefaultAsync();
        }
        public async Task<Department> UpdatedAsync(int employeeId, Department department)
        {
            var departmentToBeUpdated = await GetEmployeeAsync(employeeId);
            departmentToBeUpdated.Name = department.Name;

            _employeeContext.Departments.Update(departmentToBeUpdated);
            _employeeContext.SaveChanges();

            return departmentToBeUpdated;
        }
        public async Task DeletedAsync(int departmentId)
        {
            var deletedDepartment = await GetEmployeeAsync(departmentId);
            _employeeContext.Departments.Remove(deletedDepartment);
            await _employeeContext.SaveChangesAsync();

        }


    }
}
