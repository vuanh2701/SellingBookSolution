    using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CategoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
             : base(httpClientFactory, configuration, httpContextAccessor)  //IHttpClientFactory để tạo đối tượng client, 
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }


        public async Task<bool> CreateCategory(CategoryCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(request.ParentId.ToString()), "parentId");
            requestContent.Add(new StringContent(languageId), "languageId");
            var response = await client.PostAsync($"/api/categories/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await Delete($"/api/categories/" + id);
        }

        public async Task<List<CategoryViewModel>> GetAll( string languageId)
        {
            return await GetListAsync<CategoryViewModel>("/api/categories?languageId=" + languageId);

        }

        

        public async Task<CategoryViewModel> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryViewModel>($"/api/categories/{id}/{languageId}");
        }

        public async Task<CategoryViewModel> GetByProductId(string languageId, int id)
        {
            return await GetAsync<CategoryViewModel>($"/api/categories/{id}/{languageId}");
        }

        public async Task<PagedResult<CategoryViewModel>> GetPagings(GetManageCategoryPagingRequest request)
        {
            var data = await GetAsync<PagedResult<CategoryViewModel>>(
                $"/api/categories/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}");

            return data;
        }

        public async Task<bool> UpdateCategory(CategoryUpdateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            requestContent.Add(new StringContent(request.ParentId.ToString()), "patentId");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PutAsync($"/api/categories/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }
    }
}
