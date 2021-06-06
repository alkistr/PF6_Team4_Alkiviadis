using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IUserLoginService
    {
        Task<Result<UserLoggedIn>> GetUserLoggedInByEmailAsync(string email);
        Result<UserOptions> LoggedInUserInfoVM();
    }
}
