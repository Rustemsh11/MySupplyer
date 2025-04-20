using Microsoft.EntityFrameworkCore;
using MySupplyer.DAL;

namespace MySupplyer.Repository
{
    public class SupplyerContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pipe> Pipes { get; set; }
        public DbSet<Gost> Gosts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehousePipes> WarehousePipes { get; set; }

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
