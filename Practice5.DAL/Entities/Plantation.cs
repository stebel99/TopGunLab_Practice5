using Practice5.Domain.Entities.Abstract;
using System.Collections.Generic;

namespace Practice5.Domain.Entities
{
    public class Plantation : BasePlacement 
    {
        public ICollection<PlantationFlower> PlantationFlowers { get; set; }
        public ICollection<Supply> Supplies { get; set; }

        public Plantation()
        {
            PlantationFlowers = new List<PlantationFlower>();
            Supplies = new List<Supply>();
        }
    }
}