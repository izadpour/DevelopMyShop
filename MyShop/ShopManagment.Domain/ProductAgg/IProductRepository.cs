using System.Collections.Generic;
using _01_Framework.Domain;
using ShopManagement.Application.Contracts.ProductAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long,Product>
    {

        EditProduct GetDetails(long id);
        Product GetProductWithCategory(long id);
        List<ProductViewModel> Search(ProductSearchModel command);
        List<ProductViewModel> GetProducts();
    }
}