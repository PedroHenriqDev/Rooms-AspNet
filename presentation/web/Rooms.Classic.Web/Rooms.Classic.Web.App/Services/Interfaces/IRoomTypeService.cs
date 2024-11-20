using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.ViewModels;
using System;
using System.Threading.Tasks;
using Rooms.Classic.Web.App.Dtos.Responses.Abstractions;

namespace Rooms.Classic.Web.App.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetByIdAsync(Guid id);
        Task<ApiResponse> CreateAsync(RoomTypeViewModel viewModel);
    }
}
