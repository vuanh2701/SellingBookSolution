using SellingBookSolution.Data.Entities;
using SellingBookSolution.ViewModels.System.Users.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SellingBookSolution.Application.Utilities.Slides;
using Microsoft.Extensions.Configuration;
using SellingBookSolution.Data.EF;
using SellingBookSolution.ViewModels.Utilities.Slides;

namespace SellingBookSolution.Application.System.Roles
{
    public class SlideService : ISlideService
    {
        private readonly SellingBookDbContext _context;

        //inject . để inject được cần khai báo trong startup
        public SlideService( SellingBookDbContext context) // được lấy từ thư viện của IDentity
        {
            _context = context;
        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }

    }
}
