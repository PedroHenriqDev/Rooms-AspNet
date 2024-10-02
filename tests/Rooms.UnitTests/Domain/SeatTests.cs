using Rooms.Domain.Entities;
using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.Domain;

public class SeatTests
{
    public readonly string _name = "Seat1";
    public readonly Guid _personId = Guid.NewGuid();

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Arrange & Act
        var seat = new Seat(name: _name, personId: _personId);

        //Assert
        Assert.True(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenNameInvalid_ShouldFalse()
    {
        //Arrange & Act
        var seat = new Seat(name: "", _personId);

        //Assert
        Assert.False(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenPersonIdInvalid_ShouldFalse()
    {
        //Arrange & Act
        var seat = new Seat(_name, Guid.Empty);

        //Assert
        Assert.False(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenPersonValid_ShouldTrue()
    {
        //Arrange
        var birthDate = new DateTime(year: 2000, month: 10, day: 2);
        var personName = new Name("Pedro", "Henrique");
        var age = new Age(birthDate);
        var seatId = Guid.NewGuid();
        var person = new Person(personName, age, seatId);

        //Act
        var seat = new Seat(_name, person);

        //Assert
        Assert.True(seat.IsValid);
    }

    [Fact]
    public void IsValid_WhenPersonInvalid_ShouldFalse()
    {
        //Arrange 
        var personName = new Name("", "");
        var age = new Age(DateTime.MinValue);
        Guid id = Guid.Empty;
        var person = new Person(personName, age, id);

        //Act
        var seat = new Seat(_name, person: person);

        //Assert
        Assert.False(seat.IsValid);
    }
}