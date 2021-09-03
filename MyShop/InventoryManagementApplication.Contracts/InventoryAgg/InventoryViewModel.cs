﻿namespace InventoryManagement.Application.Contracts.InventoryAgg
{
    public class InventoryViewModel : EditInventory
    {
        public string Product { get; set; }
        public bool InStoke { get; set; }
        public long CurrentCount { get; set; }
        public string CreationDate { get; set; }
    }
}