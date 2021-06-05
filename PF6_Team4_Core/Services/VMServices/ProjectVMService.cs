using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services.VMServices
{
    public class ProjectVMService : ProjectVMServiceInterface
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectVMService> _logger;

        public ProjectVMService(IApplicationDbContext context, ILogger<ProjectVMService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Result<List<RewardPackageOptions>> GetprojectrewardpackagesVM(int id)
        {
            throw new NotImplementedException();
        }

        public Result<ProjectOptions> GetProjectVMByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
