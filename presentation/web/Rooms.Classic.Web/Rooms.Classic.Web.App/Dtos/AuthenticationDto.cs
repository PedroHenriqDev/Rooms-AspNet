using System;

namespace Rooms.Classic.Web.App.Dtos
{
    public class AuthenticationDto
    {
        public bool Authenticated { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
