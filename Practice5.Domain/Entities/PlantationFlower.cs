using Practice5.Domain.Entities.Abstract;

namespace Practice5.Domain.Entities
{
    public class PlantationFlower : BaseIntermediateTable
    {
        public int PlantationId { get; set; }
        public Plantation Plantation { get; set; }
    }
}
