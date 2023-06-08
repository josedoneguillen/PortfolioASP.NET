using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class ProjectApiService : IProjectApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProjectApiService> logger;
        private readonly string baseUrl;

        public ProjectApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<ProjectApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
        }
        public async Task<CoreGetResponse<ProjectModel>> GetProject(int Id)
        {
            CoreGetResponse<ProjectModel> projectGet = new CoreGetResponse<ProjectModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/Project/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            projectGet = JsonConvert.DeserializeObject<CoreGetResponse<ProjectModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                projectGet.success = false;
                projectGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(projectGet.message, ex.ToString());

            }
            return projectGet;
        }

        public async Task<CoreListResponse<ProjectModel>> GetProjects()
        {
            CoreListResponse<ProjectModel> projectList = new CoreListResponse<ProjectModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Project";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            projectList = JsonConvert.DeserializeObject<CoreListResponse<ProjectModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                projectList.success = false;
                projectList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(projectList.message, ex.ToString());
            }

            return projectList;
        }

        public async Task<CoreAddResponse> SaveProject(ProjectSaveRequest projectRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Project";


                    StringContent request = new StringContent(JsonConvert.SerializeObject(projectRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateProject(ProjectSaveRequest projectRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Project";

                    StringContent request = new StringContent(JsonConvert.SerializeObject(projectRequest), Encoding.UTF8, "application/json");

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