using Flunt.Notifications;
using MediatR;
using Rooms.Domain.Commands.Responses.Interfaces;

namespace Rooms.Domain.Commands.Requests.Abstractions;

public abstract class RoomTypeCommandRequest :
    Notifiable<Notification>,
    IRequest<ICommandResponse>
{
    public abstract bool Valid();
}