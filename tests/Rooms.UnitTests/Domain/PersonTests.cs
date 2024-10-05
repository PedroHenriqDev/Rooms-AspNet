using Rooms.Domain.Entities;
using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.Domain;

public class PersonTests
{
    private readonly Name _name;
    private readonly Age _age;

    public PersonTests()
    {
        _name = new Name("Pedro", "Henrique");
        _age = new Age(new DateTime(2000, 10, 2));
    }

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();

        //Act
        var person = new Person(_name, _age, seatId);

        //Assert
        Assert.True(person.IsValid);
    }

    [Fact]
    public void IsValid_WhenNameInvalid_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();
        var name = new Name("", "H");

        //Act
        var person = new Person(name, _age, seatId);

        //Assert
        Assert.False(person.IsValid);
        Assert.Equal(3, person?.Notifications.Count);
    }
    
    [Fact]
    public void IsValid_WhenAgeInFuture_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();
        var age = new Age(new DateTime(2888, 11, 22));

        //Act
        var person = new Person(_name, age, seatId);

        //Assert
        Assert.False(age.IsValid);
        Assert.Equal(2, person?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenAgeLessThanMinValueInvalid_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();
        var age = new Age(DateTime.Now);

        //Act
        var person = new Person(_name, age, seatId);

        //Assert
        Assert.False(age.IsValid);
        Assert.Equal(1, person?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenSeatInvalid_ShouldFalse()
    {
        //Arrange
        var seat = new Seat("", Guid.Empty); 

        //Act
        var person = new Person(_name, _age, seat);
        
        //Assert
        Assert.False(person.IsValid);
        Assert.Equal(3, person?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenSeatValid_ShouldTrue()
    {
        //Arrange
        var seat = new Seat("S13", Guid.NewGuid()); 

        //Act
        var person = new Person(_name, _age, seat);
        
        //Assert
        Assert.True(person.IsValid);
    }

    [Fact]
    public void IsValid_WhenSeatIdInvalid_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.Empty;

        //Act
        var person = new Person(_name, _age, seatId);

        //Assert
        Assert.False(person.IsValid);
        Assert.Equal(1, person?.Notifications.Count);
    }

    [Fact]
    public void YearsOld_WhenBirthDateYearsIsIn2000_Should24()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();

        //Act
        var person = new Person(_name, _age, seatId);
        
        //Assert
        Assert.Equal(24, person.Age.YearsOld);
    }
}