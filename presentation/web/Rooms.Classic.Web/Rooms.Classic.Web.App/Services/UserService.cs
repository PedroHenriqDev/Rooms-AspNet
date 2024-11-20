using Newtonsoft.Json;
using Rooms.Classic.Web.App.Dtos.Responses;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.ViewModels;
using Rooms.Classic.Web.App.ViewModels.Users;
using Rooms.Classic.Web.Mvc.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rooms.Classic.Web.App.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "user/";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> RegisterAsync(RegisterUserViewModel viewModel)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(API_URL, content);

            ApiResponse apiResponse;

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<UserViewModel>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else 
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<Dictionary<string, List<string>>>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpResponse = httpResponse;
            return apiResponse;
        }
    }
}
