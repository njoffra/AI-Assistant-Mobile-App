using ProjectMobilne.Models;
using SQLite;
using ProjectMobilne.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteAsyncConnection _connection;
        public UserRepository()
        {
            _connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTableAsync<UserModel>();
        }
        public async Task AddUser(UserModel user)
        {
            var existingUser = await _connection.Table<UserModel>()
                 .Where(item => item.Id == user.Id)
                 .FirstOrDefaultAsync();
            if (existingUser is null)
            {
                existingUser.Id = user.Id;
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;

                await _connection.UpdateAsync(existingUser);
            }
            else
            {
                throw new Exception("User already exists");
            }
        }
    }
}
