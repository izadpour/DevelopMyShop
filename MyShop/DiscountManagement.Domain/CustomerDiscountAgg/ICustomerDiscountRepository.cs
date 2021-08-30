using System.Collections.Generic;
using _01_Framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscountAgg;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
