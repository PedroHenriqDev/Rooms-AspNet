using Rooms.Classic.Web.App.Dtos;
using Rooms.Classic.Web.App.Services.Interfaces;
using Rooms.Classic.Web.App.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Security;

namespace Rooms.Classic.Web.App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public void SignIn(HttpContextBase context, LoginUserViewModel viewModel, AuthenticationDto authDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, viewModel.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");
            context.Session["AccessToken"] = authDto.Token;
            context.User = new ClaimsPrincipal(claimsIdentity);
        }
    }
}
