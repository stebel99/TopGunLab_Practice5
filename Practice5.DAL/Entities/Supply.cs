using Practice5.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice5.Domain.Entities
{
    public class Supply : BaseEntity
    {
        public int? PlantationId { get; set; }
        [ForeignKey("PlantationId")]
        public Plantation Plantation { get; set; }

        public int? WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        [Required]
        [MaxLength(15)]
        public string Status { get; set; }

        public ICollection<SupplyFlower> SupplyFlowers { get; set; }

        public Supply()
        {
            SupplyFlowers = new List<SupplyFlower>();
        }
    }
}
