using Practice5.Domain;
using Practice5.Domain.Entities;
using Practice5.WebUI.Models;
using Practice5.WebUI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Web;
using Unity;

namespace Practice5.WebUI.Repositories
{
    public class PlantationRepository : IPlantationRepository
    {

        [Dependency]
        public FlowerDbContext DbContext { get; set; }
        public void CreatePlantation(Plantation plantation)
        {
            plantation.PlantationFlowers = new Collection<PlantationFlower>();
            plantation.Supplies = new Collection<Supply>();
            DbContext.Plantations.Add(plantation);
            DbContext.SaveChanges();
        }

        public void CreatePlFl(PlantationFlower plantationFlower)
        {
            DbContext.PlantationFlowers.Add(plantationFlower);
            DbContext.SaveChanges();
        }

        public void DeletePlantation(int id)
        {
            Plantation plantation = DbContext.Plantations.Find(id);
            DbContext.Entry(plantation).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public void DeletePlFl(int id)
        {
            PlantationFlower plantationFlower = DbContext.PlantationFlowers.Find(id);
            DbContext.Entry(plantationFlower).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public dynamic GetFlowersInPlantation(int plantationId)
        {
            var result = from pf in DbContext.PlantationFlowers
                         join flower in DbContext.Flowers on pf.FlowerId equals flower.Id 
                         where pf.PlantationId == plantationId
                         select new FlowersAmountViewModel
                         {
                             Id = pf.Id,
                             Name = flower.Name,
                             Amount = pf.Amount
                         };
            return result;
        }

        public Plantation GetPlantation(int id)
        {
            return DbContext.Plantations.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Plantation> GetPlantations()
        {
            return DbContext.Plantations.ToList();
        }

        public PlantationFlower GetPlFl(int id)
        {
            return DbContext.PlantationFlowers.Where(s => s.Id == id).FirstOrDefault();
        }

        public void UpdatePlantation(Plantation plantation)
        {
            DbContext.Entry(plantation).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void UpdatePlFl(PlantationFlower idplantationFlower)
        {
            DbContext.Entry(idplantationFlower).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}