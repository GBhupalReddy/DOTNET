using CompanyPlayGround.Core.Dto;
using CompanyPlayGround.Core.Entities;

namespace CompanyPlayGround.Infrastructure.Repository
{
    public interface IDepartmentRepositoy
    {
        Task<Department> CreateAsync(Department department);
        Task DeleteDepartmentAsync(int id);
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
        Task<Department> GetDepartmentAsync(int id);
        Task<Department> UpdateDepartmentAsync(int id, Department department);
    }
}