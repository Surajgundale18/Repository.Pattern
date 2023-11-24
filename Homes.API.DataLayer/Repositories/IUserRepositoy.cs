using HomeMgmtAPI.DataLayer.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.DataLayer.Repositories
{
    public interface IUserRepositoy
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Task<User> DeleteUserAsync(int id);

        Task<bool> AuthenticateAsync(string userName, string password);


    }
}
