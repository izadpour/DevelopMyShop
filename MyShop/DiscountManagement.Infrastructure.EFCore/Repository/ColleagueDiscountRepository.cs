using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscountAgg;
using DiscountManagement.Domain.ColleaugeDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            var editColleagueDiscount = _context.ColleagueDiscounts
                .Select(x => new EditColleagueDiscount
                {
                    Id = x.Id,
                    DiscountRate = x.DiscountRate,
                    ProductId = x.ProductId,
                }).AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault(x => x.Id.Equals(id));

            return editColleagueDiscount;
        }

       

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x=>new {x.Id,x.Name}).AsNoTracking().ToList();
            var query = _context.ColleagueDiscounts.Select(x =>
                new ColleagueDiscountViewModel
                {
                    Id = x.Id,
                    DiscountRate = x.DiscountRate,
                    ProductId = x.ProductId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    IsRemoved = x.IsRemoved
                });
            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId.Equals(searchModel.ProductId));
            }

            var colleagueDiscounts = query.AsNoTracking().ToList();

          colleagueDiscounts.ForEach(x=>x.Product=products.FirstOrDefault(m=>m.Id.Equals(x.ProductId))?.Name);
          return colleagueDiscounts;
        }
    }
}