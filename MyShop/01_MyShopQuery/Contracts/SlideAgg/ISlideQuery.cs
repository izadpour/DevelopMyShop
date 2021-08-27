using System.Collections.Generic;

namespace _02_MyShopQuery.Contracts.SlideAgg
{
    public interface ISlideQuery
    {
        List<SlideQueryViewModel> GetSlides();
    }
}