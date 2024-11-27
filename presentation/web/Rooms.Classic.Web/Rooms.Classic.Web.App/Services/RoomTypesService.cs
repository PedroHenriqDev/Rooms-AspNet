using Newtonsoft.Json;
using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using Rooms.Classic.Web.App.Dtos.Responses;
using Rooms.Classic.Web.App.Utils;
using System.Web;

namespace Rooms.Classic.Web.App.Services
{
    public class RoomTypesService : IRoomTypeService
    {
        private const string API_URL = "roomtypes/";
        private readonly Uri _apiBaseUrl;

        public RoomTypesService(Uri apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
        }

        public async Task<ApiResponse> GetAllAsync(HttpContextBase httpContext)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ApiResponse apiResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiBaseUrl;
                client.DefaultRequestHeaders.Authorization = HttpHeaderUtils.CreateHeaderAuth(httpContext);
                httpResponse = await client.GetAsync($"{API_URL}?pageSize={int.MaxValue}&pageIndex=1");
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<IEnumerable<RoomTypeViewModel>>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<string>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpApiResponse = httpResponse;
            return apiResponse;
        }

        public async Task<ApiResponse> GetByIdAsync(Guid id)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ApiResponse apiResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = _apiBaseUrl;
                httpResponse = await client.GetAsync(API_URL + id);
            }

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<RoomTypeViewModel>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<string>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpApiResponse = httpResponse;
            return apiResponse;

        }

        public async Task<ApiResponse> CreateAsync(RoomTypeViewModel viewModel)
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
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<RoomTypeViewModel>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                string contentJson = await httpResponse.Content.ReadAsStringAsync();
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<Dictionary<string, List<string>>>>(contentJson);
            }

            apiResponse.HttpApiResponse = httpResponse;
            return apiResponse;
        }
    }
}
