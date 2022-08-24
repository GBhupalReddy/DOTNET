using CompanyPlayGround.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyPlayGround.Infrastructure.EntityConfigaration
{
    internal class DepartmentEntityTypeConfiguarction : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");


            builder.Property(e => e.Name).HasMaxLength(20);
        }
    }
}

