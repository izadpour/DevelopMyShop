using System;

namespace DiscountManagement.Application.Contracts.CustomerDiscountAgg
{
    public class CustomerDiscountViewModel:EditCustomerDiscount
    {
        public string Product { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string CreationDate { get; set; }
    }
}