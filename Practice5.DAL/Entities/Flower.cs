using Practice5.Domain.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice5.Domain.Entities
{
    public class Flower : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Color { get; set; }

        public ICollection<PlantationFlower> PlantationFlowers { get; set; }
        public ICollection<SupplyFlower> SupplyFlowers { get; set; }
        public ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
    }
}
