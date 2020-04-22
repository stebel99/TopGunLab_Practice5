using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities.Abstract
{
    public abstract class BaseIntermediateTable
    {
        [Required]
        public int Amount { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Flower")]
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
