using System.Collections.Generic;
using _01_Framework.Application;
using InventoryManagement.Domian.InventoryAgg;
using InventoryManagementApplication.Contracts.InventoryAgg;

namespace InventoryManagementApplication
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            OperationResult operationResult = new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId.Equals(command.ProductId)))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            Inventory inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            OperationResult operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if (inventory.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            // ReSharper disable once ComplexConditionExpression
            if (_inventoryRepository.Exists(x => x.ProductId.Equals(command.ProductId)
                                                 && !x.Id.Equals(command.Id)))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            inventory.Edit(command.Id, command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            OperationResult operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            var operatorId = 0;
            inventory.Increase(command.Count,operatorId,command.Description);
            _inventoryRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            OperationResult operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            var operatorId = 1;
            inventory.Reduce(command.Count, operatorId, command.Description,0);
            _inventoryRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            OperationResult operationResult = new OperationResult();
            var operatorId = 1;
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, operatorId, item.Description,item.OrderId);
            }
            _inventoryRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}