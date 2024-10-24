using Newtonsoft.Json;
using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.Mvc.Services.Interfaces;
using Rooms.Classic.Web.Mvc.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rooms.Classic.Web.Mvc.Services
{
    public class RoomTypesService : IRoomTypeService
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "roomtypes";

        public RoomTypesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RoomTypeViewModel>> GetAllAsync() 
        {
           HttpResponseMessage response = await _httpClient.GetAsync(API_URL);
           return JsonConvert.DeserializeObject<Response<IEnumerable<RoomTypeViewModel>>>(await response.Content.ReadAsStringAsync()).Value;
        }
    }
}