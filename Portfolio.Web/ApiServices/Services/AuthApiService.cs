using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthApiService> logger;
        private readonly TokenManager tokenManager;
        private readonly string baseUrl;

        public AuthApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<AuthApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }

        public async Task<CoreGetResponse<AuthLoginModel>> Login(AuthLoginRequest authLoginRequest)
        {
            CoreGetResponse<AuthLoginModel> result = new CoreGetResponse<AuthLoginModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Auth";


                    StringContent request = new StringContent(JsonConvert.SerializeObject(authLoginRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<CoreGetResponse<AuthLoginModel>>(apiResult);
                        
                            if (response.IsSuccessStatusCode)
                            {
                                tokenManager.JwtToken = result.Data.Token;

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