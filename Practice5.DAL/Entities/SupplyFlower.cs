using Practice5.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class SupplyFlower: BaseIntermediateTable
    {
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Supply")]
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
    }
}