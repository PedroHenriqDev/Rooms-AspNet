using System.Net.Http;

namespace Rooms.Classic.Web.App.Dtos.Responses.Abstractions
{
    public abstract class ApiResponse
    {
        public ApiResponse(HttpResponseMessage httpResponse)
        {
            HttpResponse = httpResponse;
        }

        public HttpResponseMessage HttpResponse { get; set; }
    }
}
