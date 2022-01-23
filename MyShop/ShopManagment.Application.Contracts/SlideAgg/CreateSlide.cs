using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.SlideAgg
{
    public class CreateSlide
    {
        [Display(Name = "عکس")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" },ErrorMessage = ValidationMessages.InValidFileFormat)]
        public  IFormFile Picture { get; set; }

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureTitle { get; set; }

        [Display(Name = "تگ عکس")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string PictureAlt { get; set; }

        [Display(Name = "سر تیتر")]
        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Heading { get; set; }

        [Display(Name = "عنوان ")]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Title { get; set; }

        [Display(Name = "متن ")]
        [MaxLength(255, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Text { get; set; }

        [Required(ErrorMessage = ValidationMessages.RequiredMessage)]
        [Display(Name = "متن دکمه")]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string BtnText { get; set; }

        [Display(Name = "لینک")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLengthMessage)]
        public string Link { get; set; }





    }
}