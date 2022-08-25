using CompanyPlayGround.Core.Entities;
using CompanyPlayGround.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlayGround.Infrastructure.Data
{
    public partial class CompenyContext : DbContext
    {
        public CompenyContext()
        {

        }
        public CompenyContext(DbContextOptions<CompenyContext> options)
            : base(options)
        { }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server= (localDb)\MSSQLLocalDB; DataBase=CompenyDB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterEntityConfigurations();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
