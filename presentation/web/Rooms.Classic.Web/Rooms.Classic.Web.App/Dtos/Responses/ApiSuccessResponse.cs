using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using System.Net.Http;

namespace Rooms.Classic.Web.Mvc.Responses
{
    public class ApiSuccessResponse<T> : ApiResponse
    {
        public ApiSuccessResponse(HttpResponseMessage httpResponse, T value) : base(httpResponse)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}