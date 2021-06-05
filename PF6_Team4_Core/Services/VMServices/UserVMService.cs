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
    public class UserVMService : UserVMServiceInterface
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserVMService> _logger;

        public UserVMService(IApplicationDbContext context, ILogger<UserVMService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Result<List<BackerUserProjectOptions>> GetUserbackerprojectsVM(int id)
        {
            throw new NotImplementedException();
        }

        public Result<List<ProjectOptions>> GetUsercreatorprojectsVM(int id)
        {
            throw new NotImplementedException();
        }

        public Result<UserOptions> GetUserVMByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
