using SellingBookSolution.ViewModels.Catalog.Products;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ProductViewModel> GetById(int id, string languageId);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);
        Task<List<ProductViewModel>> GetLatestdProducts(string languageId, int take);

        Task<bool> UpdateProduct(ProductUpdateRequest request);
        Task<bool> DeleteProduct(int id);
    }
}
