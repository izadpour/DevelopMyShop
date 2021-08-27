using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductPictureAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            OperationResult result = new OperationResult();
            if (_productPictureRepository.Exists(x =>
                x.Picture.Equals(command.Picture) && x.ProductId.Equals(command.ProductId)))
            {
                return result.Failed(ApplicationMessages.DuplicateRecord);
            }
            else
            {
                ProductPicture productPicture = new ProductPicture(command.ProductId, command.Picture,
                    command.PictureAlt, command.PictureTitle);
                _productPictureRepository.Create(productPicture);
                _productPictureRepository.SaveChanges();
                return result.Succedded();
            }
        }

        public OperationResult Edit(EditProductPicture command)
        {
            OperationResult result = new OperationResult();
            if (_productPictureRepository.Exists(x =>
                x.Picture.Equals(command.Picture) && x.ProductId.Equals(command.ProductId) && x.Id != command.Id))
            {
                return result.Failed(ApplicationMessages.DuplicateRecord);
            }

            ProductPicture productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture.Equals(null))
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            else
            {
                productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
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