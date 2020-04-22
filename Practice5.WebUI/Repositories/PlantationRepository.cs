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

        public void DeletePlantation(int id)
        {
            Plantation plantation = DbContext.Plantations.Find(id);
            DbContext.Entry(plantation).State = System.Data.Entity.EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public Plantation GetPlantation(int id)
        {
            return DbContext.Plantations.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Plantation> GetPlantations()
        {
            return DbContext.Plantations.ToList();
        }

        public void UpdatePlantation(Plantation plantation)
        {
            DbContext.Entry(plantation).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}