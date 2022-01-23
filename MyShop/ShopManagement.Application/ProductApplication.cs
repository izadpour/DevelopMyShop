using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _categoryRepository;
        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult = new OperationResult();
            if (_productRepository.Exists(x => x.Name.Equals(command.Name)))
            {
                operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            var categorySlug = _categoryRepository.GetSlugById(command.CategoryId);
            var path = $"{categorySlug}/{command.Slug.Slugify()}";
            var pictureName= _fileUploader.Upload(command.Picture,path);
           
            Product product = new Product(command.Name, command.Code, command.ShortDescription,
                command.Description, pictureName, command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, command.Slug.Slugify(), command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult operationResult = new OperationResult();
            var product = _productRepository.GetProductWithCategory(command.Id);
            if (product.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productRepository.Exists(x => x.Name.Equals(command.Name) && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            string path = $"{product.Category.Slug}/{command.Slug.Slugify()}";
            var pictureName = _fileUploader.Upload(command.Picture,path);
            product.Edit(command.Name, command.Code,  command.ShortDescription,
                command.Description, pictureName, command.PictureAlt, command.PictureTitle, command.Keywords,
                command.MetaDescription, command.Slug.Slugify(), command.CategoryId);

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