using Microsoft.EntityFrameworkCore;
using SellingBookSolution.Application.Common;
using SellingBookSolution.Data.EF;
using SellingBookSolution.Data.Entities;
using SellingBookSolution.Data.Enums;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.Utilities.Exceptions;
using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {


        private readonly SellingBookDbContext _context; // khai báo 1 biến nội bộ để đón 
        private readonly IStorageService _storageService;
        public CategoryService(SellingBookDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            //var translations = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    var translations = new CategoryTranslation()
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = request.LanguageId
                    };
                    await _context.CategoryTranslations.AddAsync(translations);
                }
                else
                {
                    var translations = new CategoryTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        SeoDescription = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        SeoTitle = SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id,
                        
                    };
                    await _context.CategoryTranslations.AddAsync(translations);
                }
            }
        var maxSortOrder =  _context.Categories.Max(e => e.SortOrder);
        var newSortOrder = maxSortOrder + 1;
        var category = new Category()
        {
            IsShowOnHome = true,
            ParentId = request.ParentId,
            SortOrder = newSortOrder,
            Status = Status.Active,
        };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
            return category.Id;
        }


    public async Task<List<CategoryViewModel>> GetAll(string languageId)
    {
        var query = from c in _context.Categories
                    join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                    //join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                    //join c in _context.Categories on pic.CategoryId equals c.Id
                    where ct.LanguageId == languageId
                    select new { c, ct };
        return await query.Select(x => new CategoryViewModel()
        {
            Id = x.c.Id,
            Name = x.ct.Name,
            ParentId = x.c.ParentId
        }).ToListAsync();
    }

    public async Task<PagedResult<CategoryViewModel>> GetAllPaging(GetManageCategoryPagingRequest request)
    {
        //1. Select join
        var query = from c in _context.Categories
                    join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId // => get products from language


                    where ct.LanguageId == request.LanguageId
                    select new { c, ct };
        //2. filter
        if (!string.IsNullOrEmpty(request.Keyword))
            query = query.Where(x => x.ct.Name.Contains(request.Keyword));


        //3. Paging
        int totalRow = await query.CountAsync();

        var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();

        //4. Select and projection
        var pagedResult = new PagedResult<CategoryViewModel>()
        {
            TotalRecords = totalRow,
            PageSize = request.PageSize,
            PageIndex = request.PageIndex,
            Items = data
        };
        return pagedResult;
    }


    public async Task<CategoryViewModel> GetById(int id, string languageId)
    {
        var query = from c in _context.Categories
                    join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                    where ct.LanguageId == languageId && c.Id == id
                    select new { c, ct };
        return await query.Select(x => new CategoryViewModel()
        {
            Id = x.c.Id,
            Name = x.ct.Name,
            ParentId = x.c.ParentId,
            SeoAlias = x.ct.SeoAlias,
            SeoDescription = x.ct.SeoDescription,
            SeoTitle = x.ct.SeoTitle,
            Status = x.c.Status,

        }).FirstOrDefaultAsync();
    }

    public async Task<int> Update(CategoryUpdateRequest request)
    {
        var category = await _context.Categories.FindAsync(request.Id);
        var categoryTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id
        && x.LanguageId == request.LanguageId);

        if (category == null || categoryTranslations == null) throw new SellingBookException($"Cannot find a category with id: {request.Id}");

        categoryTranslations.Name = request.Name;
        categoryTranslations.SeoAlias = request.SeoAlias;
        categoryTranslations.SeoDescription = request.SeoDescription;
        categoryTranslations.SeoTitle = request.SeoTitle;
        category.ParentId = request.ParentId;
        category.Status = request.Status;

        return _context.SaveChanges();
    }

    public async Task<int> Delete(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        if (category == null) throw new SellingBookException($"Cannot find a product: {categoryId}");


        _context.Categories.Remove(category);

        return await _context.SaveChangesAsync();
    }
}
}
