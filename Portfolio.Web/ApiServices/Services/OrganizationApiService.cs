using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class OrganizationApiService : IOrganizationApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<OrganizationApiService> logger;
        private readonly string baseUrl;
        private readonly TokenManager tokenManager;

        public OrganizationApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<OrganizationApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }
        public async Task<CoreGetResponse<OrganizationModel>> GetOrganization(int Id)
        {
            CoreGetResponse<OrganizationModel> organizationGet = new CoreGetResponse<OrganizationModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Organization/{Id}";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            organizationGet = JsonConvert.DeserializeObject<CoreGetResponse<OrganizationModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                organizationGet.success = false;
                organizationGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(organizationGet.message, ex.ToString());

            }
            return organizationGet;
        }

        public async Task<CoreListResponse<OrganizationModel>> GetOrganizations()
        {
            CoreListResponse<OrganizationModel> organizationList = new CoreListResponse<OrganizationModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Organization";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            organizationList = JsonConvert.DeserializeObject<CoreListResponse<OrganizationModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                organizationList.success = false;
                organizationList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(organizationList.message, ex.ToString());
            }

            return organizationList;
        }

        public async Task<CoreAddResponse> SaveOrganization(OrganizationSaveRequest organizationRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Organization";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(organizationRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateOrganization(OrganizationSaveRequest organizationRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Organization";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(organizationRequest), Encoding.UTF8, "application/json");

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