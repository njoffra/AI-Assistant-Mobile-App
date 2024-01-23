using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Repositories
{
    public interface IUserRepository
    {
        //Task<List<UserModel>> GetAllUsers();
        Task AddUser (UserModel user);
        
    }
}
