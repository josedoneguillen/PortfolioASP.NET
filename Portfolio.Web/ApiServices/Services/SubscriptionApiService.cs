using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class SubscriptionApiService : ISubscriptionApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<SubscriptionApiService> logger;
        private readonly string baseUrl;

        public SubscriptionApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<SubscriptionApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
        }
        public async Task<CoreGetResponse<SubscriptionModel>> GetSubscription(int Id)
        {
            CoreGetResponse<SubscriptionModel> subscriptionGet = new CoreGetResponse<SubscriptionModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Subscription/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            subscriptionGet = JsonConvert.DeserializeObject<CoreGetResponse<SubscriptionModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                subscriptionGet.success = false;
                subscriptionGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(subscriptionGet.message, ex.ToString());

            }
            return subscriptionGet;
        }

        public async Task<CoreListResponse<SubscriptionModel>> GetSubscriptions()
        {
            CoreListResponse<SubscriptionModel> subscriptionList = new CoreListResponse<SubscriptionModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Subscription";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            subscriptionList = JsonConvert.DeserializeObject<CoreListResponse<SubscriptionModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                subscriptionList.success = false;
                subscriptionList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(subscriptionList.message, ex.ToString());
            }

            return subscriptionList;
        }

        public async Task<CoreAddResponse> SaveSubscription(SubscriptionSaveRequest subscriptionRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Subscription";


                    StringContent request = new StringContent(JsonConvert.SerializeObject(subscriptionRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateSubscription(SubscriptionSaveRequest subscriptionRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Subscription";

                    StringContent request = new StringContent(JsonConvert.SerializeObject(subscriptionRequest), Encoding.UTF8, "application/json");

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