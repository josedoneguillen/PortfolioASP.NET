using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class RolApiService : IRolApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<RolApiService> logger;
        private readonly string baseUrl;
        private readonly TokenManager tokenManager;

        public RolApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<RolApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }
        public async Task<CoreGetResponse<RolModel>> GetRol(int Id)
        {
            CoreGetResponse<RolModel> rolGet = new CoreGetResponse<RolModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Rol/{Id}";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            rolGet = JsonConvert.DeserializeObject<CoreGetResponse<RolModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                rolGet.success = false;
                rolGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(rolGet.message, ex.ToString());

            }
            return rolGet;
        }

        public async Task<CoreListResponse<RolModel>> GetRols()
        {
            CoreListResponse<RolModel> rolList = new CoreListResponse<RolModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Rol";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            rolList = JsonConvert.DeserializeObject<CoreListResponse<RolModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                rolList.success = false;
                rolList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(rolList.message, ex.ToString());
            }

            return rolList;
        }

        public async Task<CoreAddResponse> SaveRol(RolSaveRequest rolRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Rol";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);


                    StringContent request = new StringContent(JsonConvert.SerializeObject(rolRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateRol(RolSaveRequest rolRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Rol";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(rolRequest), Encoding.UTF8, "application/json");

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