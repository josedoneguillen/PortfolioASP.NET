using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Net.Http.Headers;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class BlogPostApiService : IBlogPostApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<BlogPostApiService> logger;
        private readonly string baseUrl;
        private readonly TokenManager tokenManager;

        public BlogPostApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<BlogPostApiService> logger,
                                 TokenManager tokenManager)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            this.tokenManager = tokenManager;
        }
        public async Task<CoreGetResponse<BlogPostModel>> GetBlogPost(int Id)
        {
            CoreGetResponse<BlogPostModel> blogPostGet = new CoreGetResponse<BlogPostModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/BlogPost/{Id}";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            blogPostGet = JsonConvert.DeserializeObject<CoreGetResponse<BlogPostModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                blogPostGet.success = false;
                blogPostGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(blogPostGet.message, ex.ToString());

            }
            return blogPostGet;
        }

        public async Task<CoreListResponse<BlogPostModel>> GetBlogPosts()
        {
            CoreListResponse<BlogPostModel> blogPostList = new CoreListResponse<BlogPostModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/BlogPost";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            blogPostList = JsonConvert.DeserializeObject<CoreListResponse<BlogPostModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                blogPostList.success = false;
                blogPostList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(blogPostList.message, ex.ToString());
            }

            return blogPostList;
        }

        public async Task<CoreAddResponse> SaveBlogPost(BlogPostSaveRequest blogPostRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/BlogPost";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(blogPostRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateBlogPost(BlogPostSaveRequest blogPostRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/BlogPost";

                    // Set the Authorization header with the JWT token
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager.JwtToken);

                    StringContent request = new StringContent(JsonConvert.SerializeObject(blogPostRequest), Encoding.UTF8, "application/json");

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