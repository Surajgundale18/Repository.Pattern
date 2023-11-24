using HomeMgmtAPI.DataLayer.DataEntities;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public interface IHomeRepository
    {
        Task<List<Home>> GetAllHomesAsync();

        Task<Home> GetHomesByIdAsync(int id);

        Task<Home> CreateHomeAsync(Home home);

        Task<Home> UpdateHomeAsync(int id,Home home);

        Task<Home> DeleteHomeAsync(int id);
            

    }
}
