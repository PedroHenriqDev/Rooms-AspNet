using Newtonsoft.Json;
using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<ApiResponse<IEnumerable<RoomTypeViewModel>>> GetAllAsync() 
        {
           HttpResponseMessage response = await _httpClient.GetAsync(API_URL);
           return new ApiResponse<IEnumerable<RoomTypeViewModel>>(response, JsonConvert.DeserializeObject<IEnumerable<RoomTypeViewModel>>(await response.Content.ReadAsStringAsync()));
        }

        public async Task<ApiResponse<RoomTypeViewModel>> GetByIdAsync(Guid id) 
        {
            HttpResponseMessage response = await _httpClient.GetAsync(API_URL + id);
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<RoomTypeViewModel>>(await response.Content.ReadAsStringAsync());
            apiResponse.HttpResponse = response;
            return apiResponse;
        }
    }
}