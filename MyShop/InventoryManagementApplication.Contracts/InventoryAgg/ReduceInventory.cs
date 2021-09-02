namespace InventoryManagementApplication.Contracts.InventoryAgg
{
    public class ReduceInventory:IncreaseInventory
    {
     
        public long ProductId { get; set; }
     
        public long OrderId { get; set; }
     
    }
}