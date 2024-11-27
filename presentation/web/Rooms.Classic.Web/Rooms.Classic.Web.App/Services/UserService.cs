using Newtonsoft.Json;
using Rooms.Classic.Web.App.Dtos;
using Rooms.Classic.Web.App.Dtos.Responses;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.Utils;
using Rooms.Classic.Web.App.ViewModels;
using Rooms.Classic.Web.App.ViewModels.Users;
using Rooms.Classic.Web.Mvc.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Rooms.Classic.Web.App.Services
{
    public class UserService : IUserService
    {
        private readonly Uri _apiBaseUrl;
        private readonly IAuthenticationService _authService;
        private const string API_URL = "user/";

        public UserService(Uri apiBaseUrl, IAuthenticationService authService)
        {
            _apiBaseUrl = apiBaseUrl;
            _authService = authService;
        }

        public async Task<ApiResponse> RegisterAsync(RegisterUserViewModel viewModel)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ApiResponse apiResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiBaseUrl;
                httpResponse = await client.PostAsync(API_URL, StringContentUtils.Parse(viewModel));
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<UserViewModel>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else 
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<Dictionary<string, List<string>>>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpApiResponse = httpResponse;
            return apiResponse;
        }

        public async Task<ApiResponse> LoginAsync(HttpContextBase context, LoginUserViewModel viewModel)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ApiResponse apiResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiBaseUrl;
                httpResponse = await client.PostAsync(API_URL + "login", StringContentUtils.Parse(viewModel));
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                 apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<AuthenticationDto>>(await httpResponse.Content.ReadAsStringAsync());
                _authService.SignIn(context, viewModel, ((ApiSuccessResponse<AuthenticationDto>)apiResponse).Value);
            }
            else
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<string>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpApiResponse = httpResponse;

            return apiResponse;
        }
    }
}
