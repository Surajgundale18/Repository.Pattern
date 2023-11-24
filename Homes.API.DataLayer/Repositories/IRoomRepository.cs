using HomeMgmtAPI.DataLayer.DataEntities;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoomsAsync();

        Task<Room?> GetRoomByIdAsync(int id);

        Task<Room> CreateRoomAsync(Room room);

        Task<Room?> UpdateRoomAsync(int id,Room room);

        Task<Room> DeletRoomAsync(int id);
    }
}
