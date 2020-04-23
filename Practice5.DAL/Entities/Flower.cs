using Practice5.Domain.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice5.Domain.Entities
{
    public class Flower : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        [Display(Name="Flower Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "Flower Color")]
        public string Color { get; set; }

        public Flower()
        {
            PlantationFlowers = new List<PlantationFlower>();
            SupplyFlowers = new List<SupplyFlower>();
            WarehouseFlowers = new List<WarehouseFlower>();
        }
        public ICollection<PlantationFlower> PlantationFlowers { get; set; }
        public ICollection<SupplyFlower> SupplyFlowers { get; set; }
        public ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
    }
}
