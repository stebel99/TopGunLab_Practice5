using Practice5.Domain.Entities.Abstract;

namespace Practice5.Domain.Entities
{
    public class WarehouseFlower : BaseIntermediateTable
    {
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
