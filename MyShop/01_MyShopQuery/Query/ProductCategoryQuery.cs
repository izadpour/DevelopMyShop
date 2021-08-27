using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_MyShopQuery.Contracts.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore;

namespace _02_MyShopQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery

    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryViewModel> GetProductCategories()
        {
            var productCategoryQueryViewModels = _context.productCategories.Select(x =>
                new ProductCategoryQueryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                }).AsNoTracking().ToList();

            return productCategoryQueryViewModels;
        }
    }
}