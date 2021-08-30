using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contracts.CustomerDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public List<CustomerDiscountViewModel> CustomerDiscounts = new List<CustomerDiscountViewModel>();
        public SelectList Products;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication,
            IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }


        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

        public PartialViewResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetails(id);
            customerDiscount.Products = _productApplication.GetProducts();
            return Partial("./Create", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);

            return new JsonResult(result);
        }
    }
}