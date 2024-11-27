using Rooms.Classic.Web.App.ViewModels;
using System;
using System.Threading.Tasks;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;
using System.Web;

namespace Rooms.Classic.Web.App.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<ApiResponse> GetAllAsync(HttpContextBase httpContext);
        Task<ApiResponse> GetByIdAsync(Guid id);
        Task<ApiResponse> CreateAsync(RoomTypeViewModel viewModel);
    }
}
