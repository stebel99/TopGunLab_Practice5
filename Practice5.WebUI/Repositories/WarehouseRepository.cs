using Practice5.Domain;
using Practice5.Domain.Entities;
using Practice5.WebUI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Practice5.WebUI.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        [Dependency]
        public FlowerDbContext DbContext { get; set; }
        public void CreateWarehouse(Warehouse warehouse)
        {
            DbContext.Warehouses.Add(warehouse);
            DbContext.SaveChanges();
        }

        public void DeleteWarehouse(int id)
        {
            Warehouse warehouse = DbContext.Warehouses.Find(id);
            DbContext.Entry(warehouse).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Warehouse GetWarehouse(int id)
        {
            return DbContext.Warehouses.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return DbContext.Warehouses.ToList();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            DbContext.Entry(warehouse).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}