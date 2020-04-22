using Practice5.Domain.Entities;
using System.Collections.Generic;


namespace Practice5.WebUI.Repositories.Interfaces
{
    interface IPlantationFlowersController
    {
        IEnumerable<PlantationFlower> GetPlantationFlowers();
        PlantationFlower GetPlantationFlower(int flowerId, int PlantationId);
        void CreatePlantationFlower(PlantationFlower plantationFlower);
        void UpdatePlantationFlower(PlantationFlower plantationFlower);
        void DeletePlantationFlower(int flowerId, int PlantationId);
    }
}
