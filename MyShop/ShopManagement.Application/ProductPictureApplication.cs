using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository,IFileUploader fileUploader, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            OperationResult result = new OperationResult();
            //if (_productPictureRepository.Exists(x =>
            //    x.Picture.Equals(command.Picture) && x.ProductId.Equals(command.ProductId)))
            //{
            //    return result.Failed(ApplicationMessages.DuplicateRecord);
            //}
            var product = _productRepository.GetProductWithCategory(command.ProductId);
            string path = $"{product.Category.Slug}/{product.Slug}";
                var fileName = _fileUploader.Upload(command.Picture,path);
                ProductPicture productPicture = new ProductPicture(command.ProductId, fileName,
                    command.PictureAlt, command.PictureTitle);
                _productPictureRepository.Create(productPicture);
                _productPictureRepository.SaveChanges();
                return result.Succedded();
            
        }

        public OperationResult Edit(EditProductPicture command)
        {
            OperationResult result = new OperationResult();
          
            ProductPicture productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productPicture.Equals(null))
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            else
            {
                
                string path = $"{productPicture.Product.Category.Slug}/{productPicture.Product.Slug}";
                var fileName = _fileUploader.Upload(command.Picture, path);

                productPicture.Edit(command.ProductId, fileName, command.PictureAlt, command.PictureTitle);
                _productPictureRepository.SaveChanges();
                return result.Succedded();
            }
        }

        public OperationResult Remove(long id)
        {
            OperationResult result = new OperationResult();
            ProductPicture productPicture = _productPictureRepository.Get(id);
            if (productPicture.Equals(null))
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            else
            {
                productPicture.Remove();
                _productPictureRepository.SaveChanges();
                return result.Succedded();
            }
        }

        public OperationResult Restore(long id)
        {
            OperationResult result = new OperationResult();
            ProductPicture productPicture = _productPictureRepository.Get(id);
            if (productPicture.Equals(null))
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            else
            {
                productPicture.Restore();
                _productPictureRepository.SaveChanges();
                return result.Succedded();
            }
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel command)
        {
            return _productPictureRepository.Search(command);
        }
    }
}