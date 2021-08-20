using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategoryAgg
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);

        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}