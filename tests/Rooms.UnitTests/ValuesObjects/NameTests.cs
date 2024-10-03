using Rooms.Domain.ValueObjects;

namespace Rooms.UnitTests.ValuesObjects;

public class NameTests
{
    private readonly string _firstName = "Pedro";
    private readonly string _lastName = "Henrique";

    [Fact]
    public void IsValid_WhenParametersValid_ShouldTrue()
    {
        // Act
        var name = new Name(_firstName, _lastName);

        // Assert
        Assert.True(name.IsValid);
    }

    
    [Fact]
    public void IsValid_WhenLastNameIsEmpty_ShouldFalse()
    {
        //Arrange
        var lastName = "";
        
        // Act
        var name = new Name(_firstName, lastName);

        // Assert
        Assert.False(name.IsValid);
        Assert.Equal(2, name?.Notifications.Count);
    }

        
    [Fact]
    public void IsValid_WhenLastNameIsLowerThenMinLength_ShouldFalse()
    {
        //Arrange
        var lastName = "He";
        
        // Act
        var name = new Name(_firstName, lastName);

        // Assert
        Assert.False(name.IsValid);
        Assert.Equal(1, name?.Notifications.Count);
    }

    [Fact]
    public void IsValid_WhenFirstNameIsEmpty_ShouldFalse()
    {
        //Arrange
        var firstName = "";
        
        // Act
        var name = new Name(firstName, _lastName);

        // Assert
        Assert.False(name.IsValid);
        Assert.Equal(2, name?.Notifications.Count);
    }

    
    [Fact]
    public void IsValid_WhenFirstNameIsGreaterThanMaxLength_ShouldFalse()
    {
        //Arrange
        var firstName = new string('a', 100);
        
        // Act
        var name = new Name(firstName, _lastName);

        // Assert
        Assert.False(name.IsValid);
        Assert.Equal(1, name?.Notifications.Count);
    }
}