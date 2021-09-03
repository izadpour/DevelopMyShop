using System.Collections.Generic;
using _01_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application.Contracts.InventoryAgg;

namespace InventoryManagement.Domian.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}