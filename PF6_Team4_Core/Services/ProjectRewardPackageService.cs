using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    public class ProjectRewardPackageService : IProjectRewardPackageService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectRewardPackageService> _logger;

        public ProjectRewardPackageService(IApplicationDbContext context, ILogger<ProjectRewardPackageService> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
