
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using System.Net.Http;

namespace Rooms.Classic.Web.App.Dtos.Responses
{
    public class ApiErrorResponse<T> : ApiResponse
    {
        public ApiErrorResponse(HttpResponseMessage httpResponse, T errors) : base(httpResponse) 
        {
            Errors = errors;
        }

        public T Errors { get; set; }
    }
}
