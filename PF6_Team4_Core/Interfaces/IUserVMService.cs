using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using PF6_Team4_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IUserVMService
    {
        Result<UserOptions> GetUserVMByIdAsync();
        Result<List<ProjectOptions>> GetUsercreatorprojectsVM(int id);
        Result<List<BackerUserProjectOptions>> GetUserbackerprojectsVM(int id);
        Result<UserVM> CreateUserVM(int id);
    }
}
