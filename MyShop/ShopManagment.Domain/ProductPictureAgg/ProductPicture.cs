using System.Runtime.Intrinsics.X86;
using _01_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemove { get; private set; }
        public long ProductId { get; private set; }
        public Product Product { get; private set; }

        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;
        }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            if(!string.IsNullOrWhiteSpace(picture))
             Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Remove()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}