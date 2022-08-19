using EmployeePlayGround.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
