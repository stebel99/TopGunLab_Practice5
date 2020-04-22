using Practice5.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class PlantationFlower : BaseIntermediateTable
    {
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Plantation")]
        public int PlantationId { get; set; }
        public Plantation Plantation { get; set; }
    }
}
