using System.Net.Http;

namespace Rooms.Classic.Web.Mvc.Responses
{
    public class ApiResponse<T>
    {
        public HttpResponseMessage HttpResponse { get; set; }
        public T Value { get; set; }

        public ApiResponse(HttpResponseMessage httpResponse, T value)
        {
            HttpResponse = httpResponse;
            Value = value;
        }
    }
}