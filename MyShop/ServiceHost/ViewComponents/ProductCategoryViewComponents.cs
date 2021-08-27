using _02_MyShopQuery.Contracts.ProductCategoryAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class ProductCategoryViewComponents:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponents(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            return View(_productCategoryQuery.GetProductCategories());
        }
    }
}