using Rooms.Classic.Web.App.Dtos;
using Rooms.Classic.Web.App.ViewModels.Users;
using System.Web;

namespace Rooms.Classic.Web.App.Services.Interfaces
{
    public interface IAuthenticationService
    {
        void SignIn(HttpContextBase context, LoginUserViewModel viewModel, AuthenticationDto dto);
    }
}
