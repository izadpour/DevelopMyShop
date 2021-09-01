using System.Collections.Generic;
using ShopManagement.Application.Contracts.ProductAgg;

namespace DiscountManagement.Application.Contracts.ColleagueDiscountAgg
{
    public class DefineColleagueDiscount
    {
        public long ProductId { get; set; }
        public float DiscountRate { get; set; } 
        public List<ProductViewModel> Products { get; set; }

    }
}