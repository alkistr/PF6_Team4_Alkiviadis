using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Models;

namespace PF6_Team4_Core.Interfaces
{
    public interface IRewardPackageServices
    {
        Task<Result<List<RewardPackage>>> GetAllRewardPackagesAsync();

        Task<Result<RewardPackage>> CreateRewardPackageAsync(RewardPackage rewardpackageoptions);

        Task<Result<RewardPackage>> GetRewardPackageByIdAsync(int id);

        Task<Result<int>> DeleteRewardPackageByIdAsync(int id);
    }
}

