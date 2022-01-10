using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;

namespace Shop.Management.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            var editProduct = _context.Products
                .Select(x => new EditProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    //Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    CategoryId = x.CategoryId,
                }).AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
            return editProduct;
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).AsNoTracking().ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Picture = x.Picture,
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId,
                    CreationDate = x.CreationDate.ToFarsi(),
                });

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            if (!string.IsNullOrWhiteSpace(command.Code))
            {
                query = query.Where(x => x.Code.Contains(command.Code));
            }

            if (command.CategoryId != 0)
            {
                query = query.Where(x => x.CategoryId.Equals(command.CategoryId));
            }

            return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
        }
    }
}