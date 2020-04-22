using Practice5.Domain.Entities;
using System.Collections.Generic;

namespace Practice5.WebUI.Repositories.Interfaces
{
    public interface IFlowerRepository
    {
        IEnumerable<Flower> GetFlowers();
        Flower GetFlower(int id);
        void CreateFlower(Flower flower);
        void UpdateFlower(Flower flower);
        void DeleteFlower(int id);
    }
}
