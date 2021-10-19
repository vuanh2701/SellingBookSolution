using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) 
            : base(httpClientFactory, configuration, httpContextAccessor)  //IHttpClientFactory để tạo đối tượng client, 
        {

        }



        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageViewModel>>>("/api/languages");
 
        }
    }
}
