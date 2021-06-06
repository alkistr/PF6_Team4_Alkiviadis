using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
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

        //login class
        public async Task<Result<UserLoggedIn>> GetUserLoggedInByEmailAsync(string email)
        {
            var userLoggedIn = await _context
                            .Users
                            .SingleOrDefaultAsync(_userLogIn => _userLogIn.Email == email);

            if (userLoggedIn == null)
            {
                return new Result<UserLoggedIn>(ErrorCode.NotFound, $"User with id #{email} not found.");
            }

            //save to a stack the user that last logged in
            var userlogin = new UserLoggedIn()
            { 
                UserId = userLoggedIn.UserId,
                Email = userLoggedIn.Email,

            };                 

            return new Result<UserLoggedIn>
            {
                Data = userlogin
            };
        }

        public Result<UserOptions> LoggedInUserInfoVM()
        {
            var email = _context
                        .UsersLoggedIn
                        .OrderByDescending(x => x.UserLoggedInId)
                        .First()                        
                        .Email;


            var  userlogin = _context
                            .Users
                            .SingleOrDefaultAsync(_userLogIn => _userLogIn.Email == email);

            var userlastlog = new UserOptions()
            {
                FirstName = userlogin.Result.FirstName,
                Email = userlogin.Result.Email,
                LastName = userlogin.Result.LastName,
                Address = userlogin.Result.Address,
                UserOptionsId = userlogin.Result.UserId
            };

            return new Result<UserOptions>
            {
                Data = userlastlog
            };
        }
    }
}
