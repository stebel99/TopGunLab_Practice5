using Practice5.Domain.Entities.Abstract;
using System.Collections.Generic;

namespace Practice5.Domain.Entities
{
    public class Warehouse : BasePlacement
    {
        public ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
        public ICollection<Supply> Supplies { get; set; }

        public Warehouse()
        {
            WarehouseFlowers = new List<WarehouseFlower>();
            Supplies = new List<Supply>();
        }
    }
}
