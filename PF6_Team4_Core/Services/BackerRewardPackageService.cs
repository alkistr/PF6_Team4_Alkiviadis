using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
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

        public async Task<Result<BackerRewardPackage>> CreateBackerRewardPackageAsync(BackerRewardPackage backerrewardpackageoptions)
        {
            var backerrewardpackages = new BackerRewardPackage
            {
                UserId = backerrewardpackageoptions.UserId,
                RewardpackageId = backerrewardpackageoptions.RewardpackageId
            };

            await _context.BackerRewardPackages.AddAsync(backerrewardpackages);
            await _context.SaveChangesAsync();

            return new Result<BackerRewardPackage>
                {
                    Data = backerrewardpackages
                };
        }

        public Result<List<BackerRewardPackage>> GetAllRewardPackagesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
