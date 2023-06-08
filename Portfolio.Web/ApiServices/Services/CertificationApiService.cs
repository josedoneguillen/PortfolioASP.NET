using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class CertificationApiService : ICertificationApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CertificationApiService> logger;
        private readonly string baseUrl;

        public CertificationApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<CertificationApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
        }
        public async Task<CoreGetResponse<CertificationModel>> GetCertification(int Id)
        {
            CoreGetResponse<CertificationModel> certificationGet = new CoreGetResponse<CertificationModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Certification/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            certificationGet = JsonConvert.DeserializeObject<CoreGetResponse<CertificationModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                certificationGet.success = false;
                certificationGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(certificationGet.message, ex.ToString());

            }
            return certificationGet;
        }

        public async Task<CoreListResponse<CertificationModel>> GetCertifications()
        {
            CoreListResponse<CertificationModel> certificationList = new CoreListResponse<CertificationModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Certification";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            certificationList = JsonConvert.DeserializeObject<CoreListResponse<CertificationModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                certificationList.success = false;
                certificationList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(certificationList.message, ex.ToString());
            }

            return certificationList;
        }

        public async Task<CoreAddResponse> SaveCertification(CertificationSaveRequest certificationRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Certification";


                    StringContent request = new StringContent(JsonConvert.SerializeObject(certificationRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateCertification(CertificationSaveRequest certificationRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Certification";

                    StringContent request = new StringContent(JsonConvert.SerializeObject(certificationRequest), Encoding.UTF8, "application/json");

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