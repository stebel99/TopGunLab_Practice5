using Practice5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5.WebUI.Repositories.Interfaces
{
    interface IFlowerRepository
    {
        IEnumerable<Flower> GetFlowers();
        Flower GetFlower(int id);
        void CreateFlower(Flower flower);
        void UpdateFlower(int id);
        void DeleteFlower(int id);
    }
}
