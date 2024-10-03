using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.ValuesObjects;

public class AgeTests
{
    [Fact]
    public void IsValid_WhenBirthDateIsValid_ShouldTrue()
    {
        //Arrange
        DateTime birthDate = new DateTime(year: 2001, month: 12, day: 12);

        //Act   
        var age = new Age(birthDate);

        //Assert
        Assert.True(age.IsValid);
    }

    [Fact]
    public void IsValid_WhenYearsOldIsLowerThanMinimalYearsOld_ShouldFalse()
    {
        //Arrange
        DateTime birthDate = DateTime.Now;

        //Act   
        var age = new Age(birthDate);

        //Assert
        Assert.False(age.IsValid);
        Assert.Equal(1, age?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenYearsOldIsGreaterThanMaxYearsOld_ShouldFalse()
    {
        //Arrange
        DateTime birthDate = DateTime.Now.AddYears(-200);

        //Act   
        var age = new Age(birthDate);

        //Assert
        Assert.False(age.IsValid);
        Assert.Equal(2, age?.Notifications.Count);
    }
}