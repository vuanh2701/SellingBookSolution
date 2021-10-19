using SellingBookSolution.Data.Entities;
using SellingBookSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using SellingBookSolution.ViewModels.System.Languages;
using SellingBookSolution.Data.EF;

namespace SellingBookSolution.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        
        private readonly IConfiguration _config;
        private readonly SellingBookDbContext _context;

        //inject . để inject được cần khai báo trong startup
        public LanguageService( IConfiguration config, SellingBookDbContext context) // được lấy từ thư viện của IDentity
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguageViewModel() 
            {
                    Id = x.Id ,
                    Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageViewModel>> (languages);
        }
    }
}
