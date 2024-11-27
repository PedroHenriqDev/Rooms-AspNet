using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Rooms.Classic.Web.App.Utils
{
    public static class StringContentUtils
    {
        public static StringContent Parse<T>(T value)
        {
            return new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
        }
    }
}
