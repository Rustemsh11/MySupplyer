using Microsoft.EntityFrameworkCore;
using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class SupplyerContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pipe> Pipes { get; set; }

        public DbSet<PipeWarehouse> PipeWarehouses { get; set; }

        public SupplyerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=supplyer;Trusted_Connection=True;");
        }
    }
}
