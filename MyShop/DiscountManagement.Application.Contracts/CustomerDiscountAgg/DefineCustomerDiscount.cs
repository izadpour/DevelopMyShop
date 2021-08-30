using ShopManagement.Application.Contracts.ProductAgg;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contracts.CustomerDiscountAgg
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }
        public float DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}