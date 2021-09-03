using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Framework.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domian.InventoryAgg;
using InventoryManagement.Application.Contracts.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditInventory GetDetails(long id)
        {
            var editEnventory = _context.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));

            return editEnventory;
        }

        public Inventory GetBy(long productId)
        {
            return _context.Inventory.AsNoTracking().FirstOrDefault(x => x.ProductId.Equals(productId));
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var query = _context.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                InStoke = x.InStoke,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToFarsi(),
                CurrentCount = x.CalculateCurrentCount()
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId.Equals(searchModel.ProductId));
            }

            //if (searchModel.InStoke)
            //{
            //    query = query.Where(x => x.InStoke);
            //}

            if (searchModel.InStoke)
            {
                query = query.Where(x => !x.InStoke);
            }

            var inventory = query.OrderByDescending(x=>x.Id).AsNoTracking().ToList();

            var products = _shopContext.Products.Select(x => new {Id = x.Id, Name = x.Name}).AsNoTracking().ToList();


            inventory.ForEach(x =>  x.Product = 
                products.FirstOrDefault(p => p.Id.Equals(x.ProductId))?.Name);

            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory= _context.Inventory.AsNoTracking().FirstOrDefault(x => x.Id.Equals(inventoryId));
            return inventory.Operations.OrderByDescending(x=>x.Id).Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                CurrentCount = x.CurrentCount,
                Count = x.Count,
                Description = x.Description,
                 Operation = x.Operation,
                 OperatorId = x.OperatorId,
                 OperationDate = x.OperationDate.ToFarsi(),
                 Operator = "مدیر",
                 OrderId = x.OrderId
            }).ToList();
        }
    }
}