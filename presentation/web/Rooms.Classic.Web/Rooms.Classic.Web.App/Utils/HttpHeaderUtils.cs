using System.Net.Http.Headers;
using System.Web;

namespace Rooms.Classic.Web.App.Utils
{
    public static class HttpHeaderUtils
    {
        public static AuthenticationHeaderValue CreateHeaderAuth(HttpContextBase context)
        {
            string token = context.Session["AccessToken"]?.ToString();
            return new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
