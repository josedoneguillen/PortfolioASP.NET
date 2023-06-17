using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CategoryApiService> logger;
        private readonly string baseUrl;
        private readonly TokenManager tokenManager;

        public CategoryApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<CategoryApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }
        public async Task<CoreGetResponse<CategoryModel>> GetCategory(int Id)
        {
            CoreGetResponse<CategoryModel> categoryGet = new CoreGetResponse<CategoryModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Category/{Id}";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            categoryGet = JsonConvert.DeserializeObject<CoreGetResponse<CategoryModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                categoryGet.success = false;
                categoryGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(categoryGet.message, ex.ToString());

            }
            return categoryGet;
        }

        public async Task<CoreListResponse<CategoryModel>> GetCategorys()
        {
            CoreListResponse<CategoryModel> categoryList = new CoreListResponse<CategoryModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Category";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            categoryList = JsonConvert.DeserializeObject<CoreListResponse<CategoryModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                categoryList.success = false;
                categoryList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(categoryList.message, ex.ToString());
            }

            return categoryList;
        }

        public async Task<CoreAddResponse> SaveCategory(CategorySaveRequest categoryRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Category";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(categoryRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<CoreAddResponse>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ErrorMessage"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }

        public async Task<CoreResponseModel> UpdateCategory(CategorySaveRequest categoryRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Category";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(categoryRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<CoreResponseModel>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ErrorMessage"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }
    }
}