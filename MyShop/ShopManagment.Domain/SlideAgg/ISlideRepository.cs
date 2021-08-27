using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Domain;
using ShopManagement.Application.Contracts.SlideAgg;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();

    }
}