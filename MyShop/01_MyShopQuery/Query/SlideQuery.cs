using System.Collections.Generic;
using System.Linq;
using _02_MyShopQuery.Contracts.SlideAgg;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore;

namespace _02_MyShopQuery.Query
{

    
    public class SlideQuery:ISlideQuery
    {

        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryViewModel> GetSlides()
        {
            var SlieQueryViewModels = _context.Slides.Where(x => x.IsRemoved.Equals(false))
                .Select(x =>
                new SlideQueryViewModel
                {
                    Text = x.Text,
                    BtnText = x.BtnText,
                     Heading = x.Heading,
                     Link = x.Link,
                     Picture = x.Picture,
                     Title = x.Title,
                     PictureAlt = x.PictureAlt,
                     PictureTitle = x.PictureTitle

                }).AsNoTracking().ToList();

            return SlieQueryViewModels;

        }
    }
}