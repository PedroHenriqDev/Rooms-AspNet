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

namespace Rooms.Classic.Web.App.Services
{
    public class RoomTypesService : IRoomTypeService
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "roomtypes/";

        public RoomTypesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(API_URL);

            ApiResponse apiResponse;

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<IEnumerable<RoomTypeViewModel>>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<string>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpResponse = httpResponse;
            return apiResponse;
        }

        public async Task<ApiResponse> GetByIdAsync(Guid id)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(API_URL + id);

            ApiResponse apiResponse;

            if (httpResponse.IsSuccessStatusCode)
            {
                apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<RoomTypeViewModel>>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<string>>(await httpResponse.Content.ReadAsStringAsync());
            }

            apiResponse.HttpResponse = httpResponse;
            return apiResponse;
        }

        public async Task<ApiResponse> CreateAsync(RoomTypeViewModel viewModel)
        {
            try
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = await _httpClient.PostAsync(API_URL, content);

                ApiResponse apiResponse;

                if (httpResponse.IsSuccessStatusCode)
                {
                    apiResponse = JsonConvert.DeserializeObject<ApiSuccessResponse<RoomTypeViewModel>>(await httpResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    string contentJson = await httpResponse.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<ApiErrorResponse<Dictionary<string, List<string>>>>(contentJson);
                }
                    
                apiResponse.HttpResponse = httpResponse;
                return apiResponse;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}