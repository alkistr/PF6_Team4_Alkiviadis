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
    public interface ProjectVMServiceInterface
    {
        Result<ProjectOptions> GetProjectVMByIdAsync(int id);
        Result<List<RewardPackageOptions>> GetprojectrewardpackagesVM(int id);
        Result<ProjectVM> CreateProjectVM(int id);
    }
}
