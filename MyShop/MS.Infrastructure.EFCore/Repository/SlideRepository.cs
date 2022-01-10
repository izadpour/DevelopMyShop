using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.SlideAgg;

namespace Shop.Management.Infrastructure.EFCore.Repository
{
    public class SlideRepository:RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly ShopContext _context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            var editSlide = _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
             /*   Picture = x.Picture*/
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                Text = x.Text
            }).AsNoTracking().FirstOrDefault(x=>x.Id.Equals(id));
            return editSlide;
        }

        public List<SlideViewModel> GetList()
        {
            var slideViewModels = _context.Slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                Heading = x.Heading,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi(),
            }).OrderByDescending(x => x.Id).AsNoTracking().ToList();
            return slideViewModels;
        }
    }
}