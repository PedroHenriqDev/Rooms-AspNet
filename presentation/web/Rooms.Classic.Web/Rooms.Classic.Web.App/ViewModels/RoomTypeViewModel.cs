using System;

namespace Rooms.Classic.Web.App.ViewModels
{
    public class RoomTypeViewModel
    {
        public RoomTypeViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public RoomTypeViewModel()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}