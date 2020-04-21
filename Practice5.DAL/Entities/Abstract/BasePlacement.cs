using System.ComponentModel.DataAnnotations;

namespace Practice5.Domain.Entities.Abstract
{
    public abstract class BasePlacement : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adress { get; set; }
    }
}