using Flunt.Notifications;
using MediatR;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Requests.Abstractions;

public abstract class RoomTypeCommandRequest :
    Notifiable<Notification>,
    IRequest<IResponse>
{
    public virtual bool Valid()
    {
        return IsValid;
    }
}