using Rooms.Domain.Entities;
using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.Domain;

public class PersonTests
{
    public readonly Name _Name;
    public readonly Age _Age;

    public PersonTests()
    {
        _Name = new Name("Pedro", "Henrique");
        _Age = new Age(new DateTime(2000, 10, 2));
    }

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();

        //Act
        var person = new Person(_Name, _Age, seatId);

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
        var person = new Person(name, _Age, seatId);

        //Assert
        Assert.False(person.IsValid);
    }

    
    [Fact]
    public void IsValid_WhenAgeInFuture_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();
        var age = new Age(new DateTime(2888, 11, 22));

        //Act
        var person = new Person(_Name, age, seatId);

        //Assert
        Assert.False(age.IsValid);
    }

    [Fact]
    public void IsValid_WhenAgeLessThanMinValueInvalid_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();
        var age = new Age(DateTime.Now);

        //Act
        var person = new Person(_Name, age, seatId);

        //Assert
        Assert.False(age.IsValid);
    }

    [Fact]
    public void IsValid_WhenSeatInvalid_ShouldFalse()
    {
        //Arrange
        var seat = new Seat("", Guid.Empty); 

        //Act
        var person = new Person(_Name, _Age, seat);
        
        //Assert
        Assert.False(person.IsValid);
    }

    [Fact]
    public void IsValid_WhenSeatValid_ShouldTrue()
    {
        //Arrange
        var seat = new Seat("S1", Guid.NewGuid()); 

        //Act
        var person = new Person(_Name, _Age, seat);
        
        //Assert
        Assert.True(person.IsValid);
    }

    [Fact]
    public void IsValid_WhenSeatIdInvalid_ShouldFalse()
    {
        //Arrange
        Guid seatId = Guid.Empty;

        //Act
        var person = new Person(_Name, _Age, seatId);

        //Assert
        Assert.False(person.IsValid);
    }

    [Fact]
    public void YearsOld_WhenBirthDateYearsIsIn2000_Should24()
    {
        //Arrange
        Guid seatId = Guid.NewGuid();

        //Act
        var person = new Person(_Name, _Age, seatId);
        
        //Assert
        Assert.Equal(24, person.Age.YearsOld);
    }
}