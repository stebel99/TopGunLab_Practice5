using Practice5.Domain;
using Practice5.Domain.Entities;
using Practice5.WebUI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Unity;

namespace Practice5.WebUI.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {

        [Dependency]
        public FlowerDbContext DbContext { get; set; }
        public void CreateFlower(Flower flower)
        {
            DbContext.Flowers.Add(flower);
            DbContext.SaveChanges();
        }

        public void DeleteFlower(int id)
        {
            Flower flower = DbContext.Flowers.Find(id);
            DbContext.Entry(flower).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Flower GetFlower(int id)
        {
            return DbContext.Flowers.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Flower> GetFlowers()
        {
            return DbContext.Flowers.ToList();
        }

        public int GetNumberPlantations(int flowerId)
        {
            var number = DbContext.PlantationFlowers?.Where(x => x.FlowerId == flowerId).Count();
            int result = number == null ? 0 : number.Value;
            return result;
        }

        public int GetNumberSupplies(int flowerId)
        {
            var number = DbContext.SupplyFlowers?.Where(x => x.FlowerId == flowerId).Count();
            int result = number == null ? 0 : number.Value;
            return result;
        }

        public int GetNumberWarehouses(int flowerId)
        {
            var number = DbContext.WarehouseFlowers?.Where(x => x.FlowerId == flowerId).Count();
            int result = number == null ? 0 : number.Value;
            return result;
        }

        public void UpdateFlower(Flower flower)
        {
            DbContext.Entry(flower).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}