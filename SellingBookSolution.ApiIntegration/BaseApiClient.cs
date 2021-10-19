using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public class BaseApiClient 
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration; // lấy được appSeting, sau đó lấy được address
        private readonly IHttpContextAccessor _httpContextAccessor;



        protected BaseApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)  //IHttpClientFactory để tạo đối tượng client, 
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;

        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        protected async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data =  (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }

        public async Task<bool> Delete(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

       
    }
}
