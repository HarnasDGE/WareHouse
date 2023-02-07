
using Microsoft.EntityFrameworkCore;
using Lager.Entities;

namespace Lager.Data
{
    public class LagerDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Material> Materials => Set<Material>(); 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StarageDbApp");
        }
    }
}

