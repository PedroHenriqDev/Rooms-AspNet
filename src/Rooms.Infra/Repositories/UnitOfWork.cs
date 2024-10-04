using System.Data;
using Rooms.Domain.Repositories;

namespace Rooms.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private readonly IPersonRepository _personRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly ISeatRepository _seatRepository;

    public UnitOfWork(IDbConnection connection)
    {
        _connection = connection;
        _personRepository = new PersonRepository(connection);
        _roomRepository = new RoomRepository(connection);
        _roomTypeRepository = new RoomTypeRepository(connection);
        _seatRepository = new SeatRepository(connection);
    }

    public IPersonRepository PersonRepository => _personRepository ?? new PersonRepository(_connection); 

    public IRoomRepository RoomRepository => _roomRepository ?? new RoomRepository(_connection);

    public IRoomTypeRepository RoomTypeRepository => _roomTypeRepository ?? new RoomTypeRepository(_connection);

    public ISeatRepository SeatRepository => _seatRepository ?? new SeatRepository(_connection);

    public void Dispose()
    {
        if(_connection.State != ConnectionState.Closed)
            _connection.Close();
    }
}