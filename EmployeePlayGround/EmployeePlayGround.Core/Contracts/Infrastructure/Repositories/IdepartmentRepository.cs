using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Core.Contracts.Infrastructure.Repositories
{
    public interface IdepartmentRepository
    {
        //Task CreateAsync(Department department);
        Task CreateRangeAsync(IEnumerable<Department> departments);
    }
}
