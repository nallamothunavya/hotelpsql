using Dapper;
using Hotelsql.Models;
using Hotelsql.Utilities;

namespace Hotelsql.Repositories;

public interface IRoomRepository
{
    
    Task<bool> Update(Room Item);
    
    Task<List<Room>> GetList();
    Task<Room> GetById(int Id);
    Task<List<Room>> GetListByGuestId(int GuestId);

    Task<Room> GetScheduleRoomId(int ScheduleId);

    Task<Room> GetListByStaffId(int StaffId);
}

public class RoomRepository : BaseRepository, IRoomRepository
{
    public RoomRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Room> GetById(int Id)
    {
        var query = $@"SELECT r.*, s.name AS staff_name FROM {TableNames.room} r
        LEFT JOIN {TableNames.staff} s ON s.id = r.staff_id 
        WHERE r.id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Room>(query, new { Id });
    }

    public async Task<List<Room>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.room}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Room>(query)).AsList();

    }

    public async Task<List<Room>> GetListByGuestId(int GuestId)
    {
        var query = $@"SELECT r.* FROM {TableNames.schedule} s 
        LEFT JOIN {TableNames.room} r ON r.id = s.room_id 
        WHERE s.guest_id = @GuestId";

        // LEFT JOIN {TableNames.guest} g ON g.id = s.guest_id 

        using (var con = NewConnection)
            return (await con.QueryAsync<Room>(query, new { GuestId })).AsList();
    }

    public async Task<Room> GetListByStaffId(int StaffId)
    {
        var query = $@"SELECT r.*FROM {TableNames.staff} s
        LEFT JOIN {TableNames.room} r ON r.staff_id = s.id
        WHERE r.staff_id = @StaffId";

        using (var con = NewConnection)

        return await con.QueryFirstOrDefaultAsync<Room>(query, new {StaffId});
    }

    public async Task<Room> GetScheduleRoomId(int ScheduleId)
    {
        var query = $@"SELECT r.* FROM {TableNames.schedule} s
        LEFT JOIN {TableNames.room} r ON r .id = s.room_id
        WHERE s.id = @ScheduleId";

        using (var con = NewConnection)

       return await con.QueryFirstOrDefaultAsync<Room>(query,new {ScheduleId});
    }

    public async Task<bool> Update(Room Item)
    {
        var query = $@"UPDATE {TableNames.room} 
        SET price=@Price WHERE id = @Id";

        using (var con = NewConnection)
            return await con.ExecuteAsync(query, Item) > 0;
    }
}