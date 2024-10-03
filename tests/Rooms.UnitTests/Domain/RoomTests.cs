using Rooms.Domain.Entities;

namespace Rooms.UnitTests.Domain;

public class RoomTests
{
    private readonly string _name; 
    private readonly List<Seat> _seats;
    private readonly RoomType _roomType;
    private readonly Seat _seat; 
    private readonly int _capacity;
    private readonly DateTime _startDate;
    private readonly DateTime _endDate; 
    private readonly Room _room;
    
    public RoomTests()
    {
        _name = "Room 1";

        _seats = new List<Seat>();

        _roomType = new RoomType("Cinema");

        long seatAmount = 3;
        for(short index = 0; index <= seatAmount; index++)
        {
          _seats.Add(new Seat($"Prod{index}", Guid.NewGuid()));
        }

        _seat = new Seat("Prod x", Guid.NewGuid());

        _capacity = 10;
        _startDate = DateTime.Now.AddDays(1);
        _endDate = DateTime.Now.AddDays(2);

        _room = new Room(_name, _capacity, _roomType.Id, _startDate, _endDate);
    }

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Act
        var room = new Room(_name, _capacity, _roomType.Id, _startDate, _endDate);

        //Assert
        Assert.True(room.IsValid);
    }


    [Fact]
    public void IsValid_WhenRoomTypeValid_ShouldTrue()
    {
        //Act
        var room = new Room(_name, _capacity, _roomType, _startDate, _endDate);

        //Assert
        Assert.True(room.IsValid);
    }

    [Fact]
    public void IsValid_WhenNameInvalid_ShouldFalse()
    {
        //Act
        var room = new Room("", _capacity, _roomType.Id, _startDate, _endDate);

        //Assert
        Assert.False(room.IsValid);
        Assert.Equal(1, room?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenDateIsNotGreaterThanMinDate_ShouldFalse()
    {
        //Arrange
        var startDate = DateTime.Now.AddDays(-3);
        var endDate = DateTime.Now.AddDays(5);

        //Act
        var room = new Room(_name, _capacity, _roomType.Id, startDate, endDate);

        //Assert
        Assert.False(room.IsValid);
        Assert.Equal(1, room?.Notifications.Count);
    }

    
    [Fact]
    public void IsValid_WhenStartDateGreaterThanEndDate_ShouldFalse()
    {
        //Arrange
        var startDate = DateTime.Now.AddDays(2);
        var endDate = DateTime.Now.AddDays(1);

        //Act
        var room = new Room(_name, _capacity, _roomType.Id, startDate, endDate);

        //Assert
        Assert.False(room.IsValid);
        Assert.Equal(1, room?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenCapacityIsNegative_ShouldFalse()
    {
        //Arrange
        int capacity = -1;

        //Act
        var room = new Room(_name, capacity, _roomType.Id, _startDate, _endDate);

        //Assert
        Assert.False(room.IsValid);
        Assert.Equal(2, room?.Notifications.Count);
    }

    
    [Fact]
    public void IsValid_WhenRoomTypeIsInvalid_ShouldFalse()
    {
        //Arrange
        var roomType = new RoomType("");

        //Act
        var room = new Room(_name, _capacity, roomType, _startDate, _endDate);

        //Assert
        Assert.False(room.IsValid);
        Assert.Equal(1, room?.Notifications.Count);
    }

    [Fact]
    public void AddSeat_WhenSeatIsValid_ShouldTrue()
    {
        //Act
        bool success = _room.AddSeat(_seat);

        //Assert
        Assert.True(success);
    }
    
    [Fact]
    public void AddSeat_WhenSeatIsInvalid_ShouldFalse()
    {
        //Arrange
        Guid personId = Guid.NewGuid();
        var seat = new Seat("", personId);

        //Act
        bool success = _room.AddSeat(seat);

        //Assert
        Assert.False(success);
    }

    [Fact]
    public void AddSeat_WhenSoldOut_ShouldFalse()
    {
        //Arrange
        int capacity = 1;
        var room = new Room(_name, capacity, _roomType.Id, _startDate, _endDate);
        Guid personId = Guid.NewGuid();
        var seat = new Seat("S1", personId);
        room.AddSeat(seat);

        //Act
        bool success = room.AddSeat(_seat);

        //Assert
        Assert.False(success);
    }

    [Fact]
    public void AddSeats_WhenListOfSeatsIsValid_ShouldTrue()
    {
        //Act
        bool success = _room.AddSeats(_seats);

        //Assert
        Assert.True(success);
    }

     [Fact]
    public void AddSeats_WhenListOfSeatsInvalid_ShouldFalse()
    {
        //Arrange
        var seat = new Seat("", Guid.Empty);
        _seats.Add(seat);

        //Act
        bool success = _room.AddSeats(_seats);

        //Assert
        Assert.False(success);
    }

}