using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.SlideAgg;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;


        public List<SlideViewModel> Slides;

        public string Message { get; set; }

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

       

    

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("./Edit", slide);
        }


        public IActionResult OnPostCreate(CreateSlide command)
        {
            var  result= _slideApplication.Create(command);
            return new JsonResult(result);

        }

        public IActionResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {

            var result = _slideApplication.Remove(id);
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


            var result = _slideApplication.Restore(id);
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
