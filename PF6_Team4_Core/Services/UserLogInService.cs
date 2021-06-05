using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    class UserLogInService : IUserLoginService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserLogInService> _logger;

        public UserLogInService(IApplicationDbContext context, ILogger<UserLogInService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<UserLoggedIn>> GetUserLoggedInByEmailAsync(string email)
        {
            var userLoggedIn = await _context
                            .Users
                            .SingleOrDefaultAsync(_userLogIn => _userLogIn.Email == email);

            if (userLoggedIn == null)
            {
                return new Result<UserLoggedIn>(ErrorCode.NotFound, $"Customer with id #{email} not found.");
            }
            else
            { 
            
            }

            //save to a stack the user that last logged in
            var userlogin = new UserLoggedIn 
            {
                UserId = userLoggedIn.UserId,
                Email = userLoggedIn.Email
            };

            return new Result<UserLoggedIn>
            {
                Data = userlogin
            };
        }
    }
}
