using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using Rooms.Classic.Web.App.ViewModels;
using Rooms.Classic.Web.App.ViewModels.Users;
using System.Threading.Tasks;

namespace Rooms.Classic.Web.App.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterAsync(RegisterUserViewModel viewModel);
    }
}
