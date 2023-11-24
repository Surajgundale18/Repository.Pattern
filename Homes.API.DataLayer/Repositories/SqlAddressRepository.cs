using HomeMgmtAPI.DataLayer.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public class SqlAddressRepository : IAddressRepository
    {
        private HomeDbContext dbContext;
        public SqlAddressRepository(HomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Address>> GetAddressAsync()
        {
            var address= await dbContext.Addresses.ToListAsync();
            return address;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await dbContext.Addresses.FirstOrDefaultAsync(x=> x.AddressId== id);
            return address;
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            await dbContext.Addresses.AddAsync(address);
            await dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(int id, Address address)
        {
            var existingAddress= await dbContext.Addresses.FirstOrDefaultAsync(x=> x.AddressId == id);
            if(existingAddress==null) 
            {
                return null;
            }
            existingAddress.Street=address.Street;
            existingAddress.City=address.City;
          
            await dbContext.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<Address> DeleteAddressAsync(int id)
        {
            var address= await dbContext.Addresses.FirstOrDefaultAsync(x=> x.AddressId== id);
            if (address==null)
            {
                return null;
            }
            dbContext.Remove(address);
            await dbContext.SaveChangesAsync();
            return address;
        }
    }
}
