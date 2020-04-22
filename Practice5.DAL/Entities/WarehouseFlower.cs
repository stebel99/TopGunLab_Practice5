using Practice5.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class WarehouseFlower : BaseIntermediateTable
    {
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
