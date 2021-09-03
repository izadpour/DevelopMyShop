using System.Collections;

namespace InventoryManagement.Application.Contracts.InventoryAgg
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public IEnumerable Products { get; set; }
    }
}