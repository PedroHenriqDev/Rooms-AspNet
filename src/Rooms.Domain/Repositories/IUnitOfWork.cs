namespace Rooms.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IPersonRepository PersonRepository {get;}
    public IRoomRepository RoomRepository {get;}
    public IRoomTypeRepository RoomTypeRepository {get;}
    public ISeatRepository SeatRepository {get;}
    public IUserRepository UserRepository { get; }
}