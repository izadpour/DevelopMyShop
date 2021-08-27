using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult = new OperationResult();
            if (_productRepository.Exists(x => x.Name.Equals(command.Name)))
            {
                operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }


            Product product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, command.Slug.Slugify(), command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepository.Get(command.Id);
            if (product.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productRepository.Exists(x => x.Name.Equals(command.Name) && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, command.Slug.Slugify(), command.CategoryId);

            _productRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult IsStoke(long id)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepository.Get(id);
            if (product.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            product.InStoke();
            _productRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public OperationResult NotInStoke(long id)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepository.Get(id);
            if (product.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            product.NotInStoke();
            _productRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            return _productRepository.Search(command);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}