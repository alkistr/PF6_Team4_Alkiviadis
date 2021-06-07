using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IUserServiceAlkiviadis
    {
        Task<Result<User>> CreateUser(UserOptions userOptions);

        Task<Result<int>> DeleteUser(int UserId);

        Task<Result<List<User>>> GetAllUsers();

        Task<Result<User>> GetUserById(int UserId);

        //Task<Result<User>> UpdateUser(UserOptions userOptions, int id);
    }
}
