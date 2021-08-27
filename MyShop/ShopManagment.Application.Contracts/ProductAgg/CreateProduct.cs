using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategoryAgg;

namespace ShopManagement.Application.Contracts.ProductAgg
{
    public class CreateProduct
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Name { get; set; }

        [Display(Name = "کد کالا")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(15, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Code { get; set; }

        [Display(Name = "قیمت واحد")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        public double UnitPrice { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات ")]
        public string Description { get; set; }

        [Display(Name = " عکس")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Picture { get; set; }

        [Display(Name = "تگ تصویر")]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان تصویر")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureTitle { get; set; }


        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Keywords { get; set; }

        [Display(Name = "توضیحات متا")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string MetaDescription { get; set; }

        [Display(Name = "اسلاگ")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Slug { get; set; }

        [Display(Name = "گروه محصول")]
        public long CategoryId { get; set; }

        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}