using Microsoft.Win32.SafeHandles;
using Rooms.Domain.Entities;
using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.Domain;

public class SeatTests
{
    private readonly string _name = "S12";
    private readonly Guid _roomId = Guid.NewGuid();

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Arrange & Act
        var seat = new Seat(name: _name, roomId: _roomId);

        //Assert
        Assert.True(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenNameInvalid_ShouldFalse()
    {
        //Arrange & Act
        var seat = new Seat(name: "", _roomId);

        //Assert
        Assert.False(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenRoomIdInvalid_ShouldFalse()
    {
        //Arrange & Act
        var seat = new Seat(_name, Guid.Empty);

        //Assert
        Assert.False(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenRoomValid_ShouldTrue()
    {
        //Arrange
        string name = "R1";
        int capacity = 10;
        Guid typeId = Guid.NewGuid();
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(2);
        var room = new Room(name, capacity, typeId, startDate, endDate);

        //Act
        var seat = new Seat(_name, room);

        //Assert
        Assert.True(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenRoomInvalid_ShouldFalse()
    {
        //Arrange 
        var name = string.Empty;
        int capacity = 10;
        Guid typeId = Guid.NewGuid();
        var startDate = DateTime.Now;
        var endDate = DateTime.Now.AddDays(1);
        var room = new Room(name, capacity, typeId, startDate, endDate);

        //Act
        var seat = new Seat(_name, room: room);

        //Assert
        Assert.False(seat.IsValid);
    }
}