using Practice5.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class PlantationFlower : BaseIntermediateTable
    {
        public int? PlantationId { get; set; }
        [ForeignKey("PlantationId")]
        public Plantation Plantation { get; set; }
    }
}
