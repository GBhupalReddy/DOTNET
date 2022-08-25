using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;
using CompanyPlayGround.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlayGround.Infrastructure.Repository
{
    public class DepartmentRepositoy : IDepartmentRepositoy
    {
        private readonly CompenyContext _compenyContext;
        public DepartmentRepositoy(CompenyContext compenyContext)
        {
            _compenyContext = compenyContext;
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
        {
            return await (from department in _compenyContext.Departments
                          select new DepartmentDto
                          {
                              Id = department.Id,
                              Name = department.Name,
                          }).ToListAsync();

        }
        public async Task<Department> GetDepartmentAsync(int id)
        {
            return await _compenyContext.Departments.FindAsync(id);

        }
        public async Task<Department> CreateAsync(Department department)
        {
            _compenyContext.Departments.Add(department);
            await _compenyContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(int id, Department department)
        {
            var dept = await GetDepartmentAsync(id);
            dept.Name = department.Name;


            _compenyContext.Departments.Update(dept);
            await _compenyContext.SaveChangesAsync();

            return dept;

        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await GetDepartmentAsync(id);
            _compenyContext.Departments.Remove(department);
            await _compenyContext.SaveChangesAsync();
        }
    }
}
