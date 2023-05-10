using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace EmployeeManagementAPI.Data
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
             .Property(e => e.employeeId)
             .UseIdentityColumn(1000, 1);

            modelBuilder.Entity<Department>()
            .Property(e => e.departmentId)
            .UseIdentityColumn(1, 1);
        }
    }


}
