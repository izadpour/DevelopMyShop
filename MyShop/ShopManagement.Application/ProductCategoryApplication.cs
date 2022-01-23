using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategoryAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        
        }


        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name.Equals(command.Name)))
            {
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            }

          
            var slug = command.Slug.Slugify();

            var fileName = _fileUploader.Upload(command.Picture, slug);
            var productCategory = new ProductCategory(command.Name, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productCategoryRepository.Exists(x => x.Name.Equals(command.Name) && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

           
            var slug = command.Slug.Slugify();
            var fileName = _fileUploader.Upload(command.Picture, slug);
            productCategory.Edit(command.Name, command.Description, fileName, command.PictureAlt,
                command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();

            return operationResult.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }
    }
}