using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    public class BackerRewardPackageService : IBackerRewardPackageService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<BackerRewardPackageService> _logger;

        public BackerRewardPackageService(IApplicationDbContext context, ILogger<BackerRewardPackageService> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
