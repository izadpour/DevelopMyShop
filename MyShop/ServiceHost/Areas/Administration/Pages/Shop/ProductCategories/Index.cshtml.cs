using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public ProductCategorySearchModel SearchModel;
        
        public List<ProductCategoryViewModel> ProductCategories = new List<ProductCategoryViewModel>();

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel )
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
           return new  JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var result = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", result);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
