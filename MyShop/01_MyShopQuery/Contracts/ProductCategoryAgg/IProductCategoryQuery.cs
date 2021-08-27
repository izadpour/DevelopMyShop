using System.Collections.Generic;

namespace _02_MyShopQuery.Contracts.ProductCategoryAgg
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryViewModel> GetProductCategories();
    }
}