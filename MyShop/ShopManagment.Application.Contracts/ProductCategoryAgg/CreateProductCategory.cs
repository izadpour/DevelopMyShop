using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategoryAgg
{
    public class CreateProductCategory
    {
        [Display(Name = "نام")]
        [MaxLength(250, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
      
        public string Name { get; set; }
        
        [Display(Name = "توضیحات")]
        [MaxLength(500,ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Description { get; set; }

        [Display(Name = "عکس")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public IFormFile Picture { get; set; }

        [Display(Name = "تگ عکس")]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureTitle { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        public string Keywords { get; set; }

        [Display(Name = "توضیحات متا")]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        public string MetaDescription { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(300, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        public string Slug { get; set; }
    }
}