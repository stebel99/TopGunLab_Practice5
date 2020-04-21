using Practice5.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practice5.Domain.Entities
{
    public class Supply : BaseEntity
    {
        public int PlantationId { get; set; }
        public Plantation Plantation { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        [MaxLength(10)]
        public string Status { get; set; }

        public ICollection<SupplyFlower> SupplyFlowers { get; set; }
    }
}
