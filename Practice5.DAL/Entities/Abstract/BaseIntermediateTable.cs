using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities.Abstract
{
    public abstract class BaseIntermediateTable:BaseEntity
    {
        [Required]
        public int Amount { get; set; }
        public int? FlowerId { get; set; }
        [ForeignKey("FlowerId")]
        public Flower Flower { get; set; }
    }
}
