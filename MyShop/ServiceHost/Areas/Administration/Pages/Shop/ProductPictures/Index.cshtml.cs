using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Application.Contracts.ProductPictureAgg;


namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        public List<ProductPictureViewModel> ProductPictures = new List<ProductPictureViewModel>();
        public ProductPictureSearchModel SearchModel { get; set; }
        public SelectList Products;
        [TempData] public string Message { get; set; }

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }


        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _productPictureApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public PartialViewResult OnGetCreate()
        {
            var createProductPicture = new CreateProductPicture();
            createProductPicture.Products = _productApplication.GetProducts();
            return Partial("./Create", createProductPicture);
        }

        public IActionResult OnPostCreate(CreateProductPicture command)
        {
        

            if (ModelState.IsValid)
            {
                var result = _productPictureApplication.Create(command);
                return new JsonResult(result);
            }

            return Partial("./Create", command);
            
        }

        public IActionResult OnGetEdit(long id)
        {
            var editProductPicture = _productPictureApplication.GetDetails(id);
            editProductPicture.Products = _productApplication.GetProducts();
            return Partial("./Edit", editProductPicture);
        }

        public IActionResult OnPostEdit(EditProductPicture command)
        {
            if (ModelState.IsValid)
            {
                var result = _productPictureApplication.Edit(command);
                return new JsonResult(result);
            }
            return Partial("./Edit", command);
        }

        public IActionResult OnGetRemove(long id)
        {

            var result = _productPictureApplication.Remove(id);
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
           

              var result = _productPictureApplication.Restore(id);
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