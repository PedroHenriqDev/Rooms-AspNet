using System;

namespace Rooms.Classic.Web.App.ViewModels
{
    public class RoomTypeViewModel
    {
        public RoomTypeViewModel(Guid id, string name, DateTime createdAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
        }

        public RoomTypeViewModel()
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}