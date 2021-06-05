using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface UserVMServiceInterface
    {
        Result<UserOptions> GetUserVMByIdAsync(int id);
        Result<List<ProjectOptions>> GetUsercreatorprojectsVM(int id);
        Result<List<BackerUserProjectOptions>> GetUserbackerprojectsVM(int id);

    }
}
