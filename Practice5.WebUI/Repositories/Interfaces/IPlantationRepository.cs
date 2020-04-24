using Practice5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practice5.WebUI.Repositories.Interfaces
{
    public interface IPlantationRepository
    {
        IEnumerable<Plantation> GetPlantations();
        Plantation GetPlantation(int id);
        void CreatePlantation(Plantation plantation);
        void CreatePlFl(PlantationFlower plantationFlower);
        void UpdatePlantation(Plantation plantation);
        void DeletePlantation(int id);
    }
}
