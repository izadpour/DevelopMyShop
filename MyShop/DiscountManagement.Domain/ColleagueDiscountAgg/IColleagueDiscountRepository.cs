using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscountAgg;

namespace DiscountManagement.Domain.ColleaugeDiscountAgg
{
    public interface IColleagueDiscountRepository:IRepository<long,ColleagueDiscount>
    {
        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
       
    }
}