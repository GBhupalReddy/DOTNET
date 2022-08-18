using EmployeePlayGround.Core.Dtos;
using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Core.Contracts.Infrastructure.Repositories
{
    public interface IDepartmentRepository
    {
        //Task CreateAsync(Department department);
        Task CreateRangeAsync(IEnumerable<Department> departments);
        Task<Department> UpdateAsync(int employeeId, Department department);
        Task<Department> GetDepartmentAsync(int deptId);
        Task GetDepartmetDeatilsAsync(int deapertmentId);
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(int pageIndex, int pageSize, string sortField, string sortOrder = "asc", string? filterText = null);
        public bool IsExitorNot(string? depatmentName = null, int? departmentId = null);
    }
}
