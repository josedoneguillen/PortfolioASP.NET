﻿using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using System.Text;

namespace Portfolio.Web.ApiServices.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserApiService> logger;
        private readonly string baseUrl;

        public UserApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<UserApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
        }
        public async Task<CoreGetResponse<UserModel>> GetUser(int Id)
        {
            CoreGetResponse<UserModel> userGet = new CoreGetResponse<UserModel>();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {

                    string url = $" {this.baseUrl}/User/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            userGet = JsonConvert.DeserializeObject<CoreGetResponse<UserModel>>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                userGet.success = false;
                userGet.message = this.configuration["ErrorMessage"];
                this.logger.LogError(userGet.message, ex.ToString());

            }
            return userGet;
        }

        public async Task<CoreListResponse<UserModel>> GetUsers()
        {
            CoreListResponse<UserModel> userList = new CoreListResponse<UserModel>();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/User";

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            userList = JsonConvert.DeserializeObject<CoreListResponse<UserModel>>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                userList.success = false;
                userList.message = this.configuration["ErrorMessage"];
                this.logger.LogError(userList.message, ex.ToString());
            }

            return userList;
        }

        public async Task<CoreAddResponse> SaveUser(UserSaveRequest userRequest)
        {
            CoreAddResponse result = new CoreAddResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/User";


                    StringContent request = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");

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

        public async Task<CoreResponseModel> UpdateUser(UserSaveRequest userRequest)
        {
            CoreResponseModel result = new CoreResponseModel();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/User";

                    StringContent request = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");

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