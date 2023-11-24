using HomeMgmtAPI.DataLayer.DataEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public class SqlUserRepository : IUserRepositoy
    {
        private HomeDbContext dbContext;

        public SqlUserRepository(HomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<User>> GetAllUser()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return (user);
        }


        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUSer = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            existingUSer.Name = user.Name;
            existingUSer.Password = user.Password;


            await dbContext.SaveChangesAsync();
            return existingUSer;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> AuthenticateAsync(string userName, string password)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Name == userName && x.Password == password);

            return user != null;
        }
    }
}
