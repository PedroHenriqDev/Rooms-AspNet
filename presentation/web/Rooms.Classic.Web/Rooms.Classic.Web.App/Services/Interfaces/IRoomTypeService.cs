using Rooms.Classic.Web.Mvc.Responses;
using Rooms.Classic.Web.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rooms.Classic.Web.App.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<ApiResponse<IEnumerable<RoomTypeViewModel>>> GetAllAsync();
        Task<ApiResponse<RoomTypeViewModel>> GetByIdAsync(Guid id);
    }
}
