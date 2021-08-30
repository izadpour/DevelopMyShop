using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        [TempData]
        public string Message { get; set; }

        public List<ProductViewModel> Products = new List<ProductViewModel>();
        public ProductSearchModel SearchModel ;
        public SelectList ProductCategories; 

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel SearchModel)
        {
            Products = _productApplication.Search(SearchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");

        }

        public PartialViewResult OnGetCreate()
        {
            var command = new CreateProduct {Categories = _productCategoryApplication.GetProductCategories()};

            return Partial("./Create",command);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var command = _productApplication.GetDetails(id);
            command.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("./Edit", command);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIsInStoke(long id)
        {
            var result = _productApplication.IsStoke(id);
            if (result.IsSuccedded)
            {

                return RedirectToPage("./index");
            }
            else
            {
                RedirectToPage("./index");
                Message = result.Message;
                return RedirectToPage("./index");
            }

        }
        public IActionResult OnGetNotInStoke(long id)
        {
            var result = _productApplication.NotInStoke(id);
            if (result.IsSuccedded)
            {

                return RedirectToPage("./index");
            }
            else
            {
                RedirectToPage("./index");
                Message = result.Message;
                return RedirectToPage("./index");
            }

        }
    }
}