using Practice5.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class SupplyFlower: BaseIntermediateTable
    {
        public int SupplyId { get; set; }
        [ForeignKey("SupplyId")]
        public Supply Supply { get; set; }
    }
}