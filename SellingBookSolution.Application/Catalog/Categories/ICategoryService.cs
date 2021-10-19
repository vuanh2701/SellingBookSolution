using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {

        Task<int> Create(CategoryCreateRequest request);
        Task<int> Update(CategoryUpdateRequest request);
        Task<List<CategoryViewModel>> GetAll(string languageId);
        Task<CategoryViewModel> GetById(int id, string languageId );
        Task<PagedResult<CategoryViewModel>> GetAllPaging(GetManageCategoryPagingRequest request);
        Task<int> Delete(int categoryId);
    }
}
