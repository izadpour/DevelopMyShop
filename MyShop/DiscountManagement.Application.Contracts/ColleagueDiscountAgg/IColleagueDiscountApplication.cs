using System.Collections.Generic;
using _01_Framework.Application;

namespace DiscountManagement.Application.Contracts.ColleagueDiscountAgg
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

        OperationResult Remove(long id);
        OperationResult Restore(long id);

    }
}