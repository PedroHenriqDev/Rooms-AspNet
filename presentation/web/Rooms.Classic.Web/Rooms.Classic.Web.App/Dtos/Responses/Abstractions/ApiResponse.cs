using System.Net.Http;

namespace Rooms.Classic.Web.App.Dtos.Responses.Abstractions
{
    public abstract class ApiResponse
    {
        public ApiResponse(HttpResponseMessage httpResponse)
        {
            HttpApiResponse = httpResponse;
        }

        public HttpResponseMessage HttpApiResponse { get; set; }
    }
}
