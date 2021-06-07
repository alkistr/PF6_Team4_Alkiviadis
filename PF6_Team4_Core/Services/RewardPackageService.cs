using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core
{
    class RewardPackageService : IRewardPackageServices
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<RewardPackageService> _logger;

        public RewardPackageService(IApplicationDbContext context, ILogger<RewardPackageService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<RewardPackage>> CreateRewardPackageAsync(RewardPackage rewardpackageoptions)
        {
            if (rewardpackageoptions == null)
            {
                return new Result<RewardPackage>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(rewardpackageoptions.RewardPackageName) ||
              string.IsNullOrWhiteSpace(rewardpackageoptions.RewardDescription) ||
              rewardpackageoptions.MaxAmountRoGetReward <= 0)
            {
                return new Result<RewardPackage>(ErrorCode.BadRequest, "Not all required reward package options provided.");
            }

            //var RewardPackageWithSameCode = await _context.RewardPackages.SingleOrDefaultAsync(pro => pro.Code == rewardpackageoptions.Code);

            //if (RewardPackageWithSameCode != null)
            //{
            //    return new Result<RewardPackage>(ErrorCode.Conflict, $"Product with code #{rewardpackageoptions.Code} already exists.");
            //}

            var newRewardPackage = new RewardPackage
            {
                RewardPackageName = rewardpackageoptions.RewardPackageName,
                MaxAmountRoGetReward = rewardpackageoptions.MaxAmountRoGetReward,
                RewardDescription = rewardpackageoptions.RewardDescription,
                CreationDate = DateTime.Now
            };

            await _context.RewardPackages.AddAsync(newRewardPackage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<RewardPackage>(ErrorCode.InternalServerError, "Could not save reward package.");
            }

            return new Result<RewardPackage>
            {
                Data = newRewardPackage
            };
        }

        public async Task<Result<RewardPackage>> GetRewardPackageByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<RewardPackage>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var rewardpackage = await _context
                .RewardPackages
                .SingleOrDefaultAsync(_rewardpackage => _rewardpackage.RewardPackageId == id);

            if (rewardpackage == null)
            {
                return new Result<RewardPackage>(ErrorCode.NotFound, $"Customer with id #{id} not found.");
            }

            return new Result<RewardPackage>
            {
                Data = rewardpackage
            };
        }

        public async Task<Result<int>> DeleteRewardPackageByIdAsync(int id)
        {
            var rewardpackageToDelete = await GetRewardPackageByIdAsync(id);

            if (rewardpackageToDelete.Error != null || rewardpackageToDelete.Data == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Customer with id #{id} not found.");
            }

            _context.RewardPackages.Remove(rewardpackageToDelete.Data);

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
                Data = id
            };
        }

        public async Task<Result<List<RewardPackage>>> GetAllRewardPackagesAsync()
        {
            var rewardpackages = await _context.RewardPackages.ToListAsync();

            return new Result<List<RewardPackage>>
            {
                Data = rewardpackages.Count > 0 ? rewardpackages : new List<RewardPackage>()
            };
        }

        public async Task<Result<RewardPackage>> UpdateRewardPackageAsync(int id, RewardPackage rewardpackageoptions)
        {
                        
            _context.RewardPackages.Update(rewardpackageoptions);
            await _context.SaveChangesAsync();

            return new Result<RewardPackage>
            {
                Data = rewardpackageoptions
            };
        }
    }
}
