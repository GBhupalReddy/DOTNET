using EmployeePlayGround.Infrastructure.EntityConfiguractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePlayGround.Infrastructure.Extension
{
    internal static class ModelBuilderExtension
    {
        internal static void RegisterEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguraction());
            modelBuilder.ApplyConfiguration(new DepartmentEntityTypeConfiguratiopn());
        }
    }
}
