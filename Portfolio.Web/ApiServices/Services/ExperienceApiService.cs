using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class ExperienceApiService : IExperienceApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ExperienceApiService> logger;
        private readonly string baseUrl;
        private readonly TokenManager tokenManager;

        public ExperienceApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<ExperienceApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }
        public async Task<CoreGetResponse<ExperienceModel>> GetExperience(int Id)
        {
            CoreGetResponse<ExperienceModel> experienceGet = new CoreGetResponse<ExperienceModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Experience/{Id}";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            experienceGet = JsonConvert.DeserializeObject<CoreGetResponse<ExperienceModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                experienceGet.success = false;
                experienceGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(experienceGet.message, ex.ToString());

            }
            return experienceGet;
        }

        public async Task<CoreListResponse<ExperienceModel>> GetExperiences()
        {
            CoreListResponse<ExperienceModel> experienceList = new CoreListResponse<ExperienceModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Experience";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            experienceList = JsonConvert.DeserializeObject<CoreListResponse<ExperienceModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                experienceList.success = false;
                experienceList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(experienceList.message, ex.ToString());
            }

            return experienceList;
        }

        public async Task<CoreAddResponse> SaveExperience(ExperienceSaveRequest experienceRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Experience";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(experienceRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateExperience(ExperienceSaveRequest experienceRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Experience";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(experienceRequest), Encoding.UTF8, "application/json");

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