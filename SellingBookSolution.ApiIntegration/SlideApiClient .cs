using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SellingBookSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
             : base(httpClientFactory, configuration, httpContextAccessor)  //IHttpClientFactory để tạo đối tượng client, 
        {

        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            return await GetListAsync<SlideViewModel>("/api/slides");

        }

    }
}
