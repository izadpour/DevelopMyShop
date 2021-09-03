using _01_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domian.InventoryAgg;

namespace InventoryManagement.Domian.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }

        public double UnitPrice { get; private set; }

        public bool InStoke { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStoke = false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStoke = false;
        }

        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, currentCount, operatorId, 0, description, Id);
            Operations.Add(operation);
            InStoke = CalculateCurrentCount() > 0;
        }

        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, currentCount, operatorId, orderId, description, Id);
            Operations.Add(operation);
            InStoke = CalculateCurrentCount() > 0;
        }
    }
    }

    public class InventoryOperation
    {
        public long Id { get; private set; }

        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long CurrentCount { get; private set; }
        public long OperatorId { get; private set; }
        public long OrderId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public string Description { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        protected InventoryOperation()
        {
                
        }

        public InventoryOperation(bool operation, long count, long currentCount, long operatorId, long orderId, string description, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            OrderId = orderId;
            Description = description;
            InventoryId = inventoryId;
            CurrentCount = currentCount;
            OperationDate=DateTime.Now;
        }
    }
        