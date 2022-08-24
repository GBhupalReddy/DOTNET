using CompanyPlayGround.Infrastructure.EntityConfigaration;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlayGround.Infrastructure.Extension;

internal static class ModelBuilderExtension
{
    internal static void RegisterEntityConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguarction());
        modelBuilder.ApplyConfiguration(new DepartmentEntityTypeConfiguarction());
    }
}
