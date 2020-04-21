using Practice5.Domain.Entities.Abstract;

namespace Practice5.Domain.Entities
{
    public class SupplyFlower: BaseIntermediateTable
    {
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
    }
}