using EmployeePlayGround.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeePlayGround.Infrastructure.EntityConfiguractions
{
    internal class DepartmentEntityTypeConfiguratiopn : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

           
            builder.Property(e => e.Name).HasMaxLength(20);
        }
    }
}
