using HomeMgmtAPI.DataLayer.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public class SqlRoomRepository : IRoomRepository
    {
        private HomeDbContext dbContext;
        public SqlRoomRepository(HomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            var roomDetails = await dbContext.Rooms.ToListAsync();
            return roomDetails;
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            var existingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            if (existingRoom == null)
            {
                return null;
            }
            await dbContext.SaveChangesAsync();
            return existingRoom;
        }
 
        public async Task<Room> CreateRoomAsync(Room room)
        {
            await dbContext.Rooms.AddAsync(room);
            await dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> UpdateRoomAsync(int id, Room room)
        {
           var existingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId==id);
           if (existingRoom == null)
            {
                return null;
            }
            existingRoom.RoomName = room.RoomName;
           await dbContext.SaveChangesAsync();
        return existingRoom;

        }
        public async Task<Room> DeletRoomAsync(int id)
        {
            var existingRoom = await dbContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            if (existingRoom == null)
            {
                return null;
            }
            dbContext.Rooms.Remove(existingRoom);
            await dbContext.SaveChangesAsync();
            return existingRoom;
        }
    }
}
