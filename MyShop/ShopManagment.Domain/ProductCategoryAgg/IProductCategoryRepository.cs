using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using _01_Framework.Domain;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
   public interface IProductCategoryRepository:IRepository<long,ProductCategory>
   {
      
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        List<ProductCategoryViewModel> GetProductCategories();
    }
}

