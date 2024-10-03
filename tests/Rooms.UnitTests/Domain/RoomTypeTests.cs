using Rooms.Domain.Entities;

namespace Rooms.UnitTests.Domain;

public class RoomTypeTests
{
    private readonly string _name = "Albert Planck";

    [Fact]
    public void IsValid_WhenNameValid_ShouldTrue()
    {
        //Act
        var roomType = new RoomType(_name);

        //Assert        
        Assert.True(roomType.IsValid);
    }

    [Fact]
    public void IsValid_WhenNameInvalid_ShouldFalse()
    {
        //Act
        var roomType = new RoomType("");

        //Assert        
        Assert.False(roomType.IsValid);
    }
}