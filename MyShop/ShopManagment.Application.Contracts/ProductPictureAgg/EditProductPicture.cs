using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductPictureAgg
{
    public class EditProductPicture:CreateProductPicture
    {
        public long Id { get; set; }
        [Display(Name = "عکس")]
       
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
        public new IFormFile Picture { get; set; }
    }
 }