using _02_MyShopQuery.Contracts.SlideAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class SlideViewComponents:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponents(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            return View(_slideQuery.GetSlides());
        }
        
    }
}