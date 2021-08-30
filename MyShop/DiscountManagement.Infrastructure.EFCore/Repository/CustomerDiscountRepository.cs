using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _01_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.CustomerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>,
        ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _contextShop;

        public CustomerDiscountRepository(DiscountContext context, ShopContext contextShop) : base(context)
        {
            _contextShop = contextShop;
            _context = context;
        }


        public EditCustomerDiscount GetDetails(long id)
        {
            var editCustomerDiscount = _context.CustomerDiscounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.Id,
                    DiscountRate = x.DiscountRate,
                    EndDate = x.EndDate.ToString(),
                    StartDate = x.StartDate.ToString(),
                    Reason = x.Reason
                }).FirstOrDefault(x => x.Id.Equals(id));

            return editCustomerDiscount;
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _contextShop.Products.Select(x => new {x.Id, x.Name}).AsNoTracking().ToList();
            var query = _context.CustomerDiscounts
                .Select(x => new CustomerDiscountViewModel
                {
                    Id = x.Id,
                    DiscountRate = x.DiscountRate,
                    StartDateGr = x.StartDate,
                    EndDateGr = x.EndDate,
                    StartDate = x.StartDate.ToFarsi(),
                    EndDate = x.EndDate.ToFarsi(),
                    Reason = x.Reason,
                    ProductId = x.ProductId,
                    CreationDate = x.CreationDate.ToFarsi()
                   
                });
            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId.Equals(searchModel.ProductId));
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateGr >= searchModel.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                query = query.Where(x => x.EndDateGr >= searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.AsNoTracking().ToList();
            discounts.ForEach(discount=>discount.Product=products.FirstOrDefault(x=>x.Id.Equals(discount.ProductId))?.Name);

            return discounts;
        }
    }
}