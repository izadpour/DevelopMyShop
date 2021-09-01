using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountManagement.Application.Contracts.ColleagueDiscountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts = new List<ColleagueDiscountViewModel>();
        public SelectList Products;
        [TempData] public string Message { get; set; }

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication,
            IProductApplication productApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
        }


        public PartialViewResult OnGetCreate()
        {
            var difineColleagueDiscount = new DefineColleagueDiscount
            {
                Products = _productApplication.GetProducts()
            };


            return Partial("./Create", difineColleagueDiscount);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var editColleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            editColleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("./Edit", editColleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _colleagueDiscountApplication.Remove(id);
            if (result.IsSuccedded)
            {

                return RedirectToPage("./index");
            }
            else
            {

                Message = result.Message;
                return RedirectToPage("./index");
            }
        }

        public IActionResult OnGetRestore(long id)
      
        {
            var result = _colleagueDiscountApplication.Restore(id);
            if (result.IsSuccedded)
            {

                return RedirectToPage("./index");
            }
            else
            {

                Message = result.Message;
                return RedirectToPage("./index");
            }
        }
    }
}