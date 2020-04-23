using Practice5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5.WebUI.Repositories.Interfaces
{
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> GetWarehouses();
        Warehouse GetWarehouse(int id);
        void CreateWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int id);
    }
}
