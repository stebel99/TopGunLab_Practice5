using Practice5.Domain.Entities;
using System.Data.Entity;

namespace Practice5.Domain
{
    public class FlowerDbContext : DbContext
    {
        public FlowerDbContext() : base("FlowerIndustryDb")
        {
        }
        public virtual DbSet<Flower> Flowers { get; set; }
        public virtual DbSet<Plantation> Plantations { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<PlantationFlower> PlantationFlowers { get; set; }
        public virtual DbSet<WarehouseFlower> WarehouseFlowers { get; set; }
        public virtual DbSet<SupplyFlower> SupplyFlowers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
