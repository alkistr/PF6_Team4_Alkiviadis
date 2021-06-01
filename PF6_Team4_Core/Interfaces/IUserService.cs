using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    class IUserService
    {
        public UserService(IApplicationDbContext context, ILogger<UserService> logger)

        public async Task<Result<User>> CreateUser(UserOptions userOptions)

        public async Task<Result<bool>> DeleteUser(int UserId)

        public async Task<Result<List<UserOptions>>> GetAllUsers()

        public async Task<Result<UserOptions>> GetUserById(int UserId)

        public async Task<Result<UserOptions>> UpdateUser(UserOptions usererOptions, int id)

    }
}
