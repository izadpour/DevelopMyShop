using System;
using System.Collections.Generic;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductAgg
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult IsStoke(long id);
        OperationResult NotInStoke(long id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel command);
        List<ProductViewModel> GetProducts();
    }
}