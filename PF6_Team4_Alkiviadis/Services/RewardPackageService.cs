using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team4_Alkiviadis.Interfaces;
using PF6_Team4_Alkiviadis.Models;
using PF6_Team4_Alkiviadis.Models.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Services
{
    public class RewardPackageService : IRewardPackageServices
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<RewardPackageService> _logger;

        public RewardPackageService(IApplicationDbContext context, ILogger<RewardPackageService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<RewardPackageOptions>> CreateRewardPackageAsync(RewardPackageOptions rewardpackageoptions)
        {
            if (rewardpackageoptions == null)
            {
                return new Result<RewardPackageOptions>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(rewardpackageoptions.RewardPackageName) ||
              string.IsNullOrWhiteSpace(rewardpackageoptions.RewardDescription) ||
              rewardpackageoptions.MaxAmountRoGetReward <=0)
            {
                return new Result<RewardPackageOptions>(ErrorCode.BadRequest, "Not all required reward package options provided.");
            }

            //var RewardPackageWithSameCode = await _context.RewardPackages.SingleOrDefaultAsync(pro => pro.Code == rewardpackageoptions.Code);

            //if (RewardPackageWithSameCode != null)
            //{
            //    return new Result<RewardPackage>(ErrorCode.Conflict, $"Product with code #{rewardpackageoptions.Code} already exists.");
            //}

            var newRewardPackage = new RewardPackageOptions
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

                return new Result<RewardPackageOptions>(ErrorCode.InternalServerError, "Could not save reward package.");
            }

            return new Result<RewardPackageOptions>
            {
                Data = newRewardPackage
            };
        }

        public async Task<Result<RewardPackageOptions>> GetRewardPackageByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<RewardPackageOptions>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var rewardpackage = await _context
                .RewardPackages
                .SingleOrDefaultAsync(_rewardpackage => _rewardpackage.RewardPackageId == id);

            if (rewardpackage == null)
            {
                return new Result<RewardPackageOptions>(ErrorCode.NotFound, $"Customer with id #{id} not found.");
            }

            return new Result<RewardPackageOptions>
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

        public async Task<Result<List<RewardPackageOptions>>> GetAllRewardPackagesAsync()
        {
            var rewardpackages = await _context.RewardPackages.ToListAsync();

            return new Result<List<RewardPackageOptions>>
            {
                Data = rewardpackages.Count > 0 ? rewardpackages : new List<RewardPackageOptions>()
            };
        }

        
    }
}
