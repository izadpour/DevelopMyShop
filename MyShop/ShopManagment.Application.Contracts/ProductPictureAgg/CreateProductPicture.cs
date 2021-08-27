using System.Collections;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductPictureAgg
{
    public class CreateProductPicture
    {
        [Display(Name = "محصول")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
       public long ProductId { get;  set; }

       [Display(Name = "عکس")]
       [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
       [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Picture { get;  set; }

        [Display(Name = "تگ عکس")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureAlt { get;  set; }


        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureTitle { get;  set; }

        public IEnumerable Products { get; set; }
    }
}