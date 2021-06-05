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
    public class UserService : IUserService_alkiviadis
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
            if (userOptions == null)
            {
                return new Result<User>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(userOptions.FirstName) ||
              string.IsNullOrWhiteSpace(userOptions.LastName) ||
              string.IsNullOrWhiteSpace(userOptions.Email))
            {
                return new Result<User>(ErrorCode.BadRequest, "Not all required customer options provided.");
            }
            var customerWithSameEmail = await _context.Users.SingleOrDefaultAsync(cus => cus.Email == userOptions.Email);

            if (customerWithSameEmail!= null)
            {
                return new Result<User>(ErrorCode.Conflict, $"Customer with #{userOptions.Email} already exists.");
            }

            var newUser = new User
            {
                Email = userOptions.Email,
                FirstName = userOptions.FirstName,
                LastName = userOptions.LastName,
                Address = userOptions.Address
            };

            await _context.Users.AddAsync(newUser);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<User>(ErrorCode.InternalServerError, "Could not save customer.");
            }

            return new Result<User>
            {
                Data = newUser
            };
        }

         public async Task<Result<User>> GetUserById(int UserId)
         {
            if (UserId <= 0)
            {
                return new Result<User>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var user = await _context
                .Users
                .SingleOrDefaultAsync(cus => cus.UserId == UserId);

            if (user == null)
            {
                return new Result<User>(ErrorCode.NotFound, $"Customer with id #{UserId} not found.");
            }

            return new Result<User>
            {
                Data = user
            };
        }
        
        public async Task<Result<int>> DeleteUser(int UserId)
        {
            var customerToDelete = await GetUserById(UserId);

            if (customerToDelete.Error != null || customerToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Customer with id #{UserId} not found.");
            }

            _context.Users.Remove(customerToDelete.Data);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete customer.");
            }

            return new Result<int>
            {
                Data = UserId
            };
        }

        public async Task<Result<List<User>>> GetAllUsers()
        {
            var customers = await _context.Users.ToListAsync();

            return new Result<List<User>>
            {
                Data = customers.Count > 0 ? customers : new List<User>()
            };
        }

       

        public async Task<Result<User>> UpdateUser(UserOptions userOptions, int UserId)
        {
            var userToUpdate = await GetUserById(UserId);

            if (userToUpdate.Error != null || userToUpdate.Data == null)
            {
                return new Result<User>(ErrorCode.NotFound, $"Customer with id #{UserId} not found.");
            }

            var user = await _context
                .Users
                .SingleOrDefaultAsync(cus => cus.UserId == UserId);

            UserOptions userToUpdate =  userOptions
            {
                Email = userOptions.Email,
                FirstName = userOptions.FirstName,
                LastName = userOptions.LastName,
                Address = userOptions.Address
            };

            _context.Update(userToUpdate);
            await _context.SaveChangesAsync();

            return userToUpdate;
        }
    }
}
