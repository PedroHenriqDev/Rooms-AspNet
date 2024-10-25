using Rooms.Classic.Web.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rooms.Classic.Web.Mvc.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeViewModel>> GetAllAsync();
        Task<RoomTypeViewModel> GetByIdAsync(Guid id);
    }
}
