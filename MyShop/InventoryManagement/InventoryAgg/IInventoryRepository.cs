using System.Collections.Generic;
using _01_Framework.Domain;
using InventoryManagementApplication.Contracts.InventoryAgg;

namespace InventoryManagement.Domian.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}