using Rooms.Domain.Entities;
using Rooms.Domain.Enums;

namespace Rooms.UnitTests.Domain;

public class RoomTests
{
    public readonly string _Name; 
    public readonly List<Seat> _Seats;

    public RoomTests()
    {
        _Name = "Room 1";

        _Seats = new List<Seat>();

        long seatAmount = 10;
        for(short index = 0; index <= seatAmount; index++)
        {
          _Seats.Add(new Seat($"Prod{index}", Guid.NewGuid()));
        }
    }

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Arrange
        int capacity = 10;

        //Act
        var room = new Room(_Name, capacity, ERoomType.Cinema);

        //Assert
        Assert.True(room.IsValid);
    }
}