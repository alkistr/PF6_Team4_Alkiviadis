using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Models.Options.ProjectOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    public class UserService : IUserService

    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(IApplicationDbContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public async Task<Result<User>> CreateUser(UserOptions userOptions)
        {
            User user = new User
            {
                UserId = userOptions.UserId,
                FirstName = userOptions.FistName,
                LastName = userOptions.LastName,
                Email = userOptions.Email,
                CreationDate = DateTime.Now,
                Address = userOptions.Address,   
            };

            await _context.UserOptions.AddAsync(new User);


        public async Task<Result<bool>>DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<UserOptions>>> GetAllUsers()
        {
            List<User> users = _context.users.ToList();

            List<UserOptions> usersOptions = new List<UserOptions>();

            users.ForEach(users => usersOptions.AddAsync(new UserOptions())
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                
            }));

            await _context.UserOptions.AddAsync(new User);

        }
        public async Task<Result<UserOptions>> GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }


        public async Task<Result<UserOptions>> UpdateUser(UserOptions usererOptions, int id)
        {
            throw new NotImplementedException();
        }
    }
}

    

