using HomeMgmtAPI.DataLayer.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public class SqlHomeRepository : IHomeRepository
    {
        private HomeDbContext dbContext;

        public SqlHomeRepository(HomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<List<Home>> GetAllHomesAsync()
        {
            var homes = await dbContext.Homes
                .Include(home => home.Address)
                .Include(home => home.Rooms)
                .ToListAsync();

            return homes;
        }

        public async Task<Home> GetHomesByIdAsync(int id)
        {
            var home = await dbContext.Homes.FirstOrDefaultAsync(x => x.HomeId == id);

            return home;
        }
        public async Task<Home> CreateHomeAsync(Home home)
        {
            await dbContext.Homes.AddAsync(home);
            await dbContext.SaveChangesAsync();
            return (home);
        }


        public async Task<Home> UpdateHomeAsync(int id, Home home)
        {
            var existingHome = await dbContext.Homes.FirstOrDefaultAsync(home => home.HomeId == id);

            if (existingHome == null)
            {
                return null;
            }

            existingHome.HomeName = home.HomeName;


            await dbContext.SaveChangesAsync();
            return existingHome;
        }

        public async Task<Home> DeleteHomeAsync(int id)
        {
            var existingHome = await dbContext.Homes.FirstOrDefaultAsync(x => x.HomeId == id);
            if (existingHome == null)
            {
                return null;
            }

            dbContext.Homes.Remove(existingHome);
            await dbContext.SaveChangesAsync();
            return existingHome;
        }


    }
}
