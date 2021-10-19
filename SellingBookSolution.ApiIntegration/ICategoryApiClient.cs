using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Catalog.Products;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
        Task<CategoryViewModel> GetById(string languageId, int id);

        Task<CategoryViewModel> GetByProductId(string languageId, int id);

        Task<PagedResult<CategoryViewModel>> GetPagings(GetManageCategoryPagingRequest request);

        Task<bool> CreateCategory(CategoryCreateRequest request);
        Task<bool> UpdateCategory(CategoryUpdateRequest request);
        Task<bool> DeleteCategory(int id);
    }
}
