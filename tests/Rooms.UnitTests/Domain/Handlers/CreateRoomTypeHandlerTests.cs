using System.Net;
using Flunt.Notifications;
using Moq;
using Rooms.Domain.Commands.Handlers.RoomTypes;
using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Entities;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.UnitTests.Domain.Handlers;

public class CreateRoomTypeHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CreateRoomTypeHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();

        _unitOfWorkMock.Setup(m => m.RoomTypeRepository
                              .CreateAsync(It.IsAny<RoomType>()))
                              .ReturnsAsync(() => true);
    }

    [Fact]
    public async Task Handle_WhenCommandRequestIsValid_ShouldReturnSuccessTrue()
    {
        //Arrange
        var commandRequest = new CreateRoomTypeRequest("Cinema");

        _unitOfWorkMock?.Setup(m => m.RoomTypeRepository
                               .ExistsNameAsync(It.IsAny<string>()))
                               .ReturnsAsync(() => false);

        var handler = new CreateRoomTypeHandler(_unitOfWorkMock!.Object);

        //Act
        IResponse commandResponse =  await handler.Handle(commandRequest, CancellationToken.None);

        //Assert
        Assert.True(commandResponse.Success);
        Assert.IsType<RoomType>(commandResponse.Value);
        Assert.Equal(HttpStatusCode.Created, commandResponse.StatusCode);
        Assert.NotNull(commandResponse.Message);
    }

    [Fact]
    public async Task Handle_WhenCommandRequestIsInvalid_ShouldReturnSuccessFalse()
    {
        //Arrange
        var commandRequest = new CreateRoomTypeRequest();

        var handler = new CreateRoomTypeHandler(_unitOfWorkMock!.Object);

        //Act
        IResponse commandResponse =  await handler.Handle(commandRequest, CancellationToken.None);

        //Assert
        Assert.False(commandResponse.Success);
        Assert.IsType<List<Notification>>(commandResponse.Value);
        Assert.Equal(HttpStatusCode.BadRequest, commandResponse.StatusCode);
        Assert.NotNull(commandResponse.Message);
    }

    [Fact]
    public async Task Handle_WhenCommandRequestNameExists_ShouldReturnSuccessFalse()
    {
        //Arrange
        var commandRequest = new CreateRoomTypeRequest("Cinema");
        
        _unitOfWorkMock?.Setup(m => m.RoomTypeRepository
                               .ExistsNameAsync(It.IsAny<string>()))
                               .ReturnsAsync(() => true);

        var handler = new CreateRoomTypeHandler(_unitOfWorkMock!.Object);

        //Act
        IResponse commandResponse =  await handler.Handle(commandRequest, CancellationToken.None);

        //Assert
        Assert.False(commandResponse.Success);
        Assert.IsType<string>(commandResponse.Value);
        Assert.Equal(HttpStatusCode.BadRequest, commandResponse.StatusCode);
        Assert.NotNull(commandResponse.Message);
    }
}