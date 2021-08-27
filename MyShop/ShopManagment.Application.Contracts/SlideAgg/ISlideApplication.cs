using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.SlideAgg
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}