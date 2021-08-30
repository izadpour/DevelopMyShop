using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscountAgg
{
    public class CustomerDiscountSearchModel
    {
        
        public long ProductId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}