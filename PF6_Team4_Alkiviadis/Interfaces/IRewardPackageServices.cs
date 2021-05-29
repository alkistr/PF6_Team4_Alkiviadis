using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Alkiviadis.Models;
using PF6_Team4_Alkiviadis.Models.Options;

namespace PF6_Team4_Alkiviadis.Interfaces
{
    public interface IRewardPackageServices
    {
        Task<Result<List<RewardPackageOptions>>> GetAllRewardPackagesAsync();

        Task<Result<RewardPackageOptions>> CreateRewardPackageAsync(RewardPackageOptions rewardpackageoptions);

        Task<Result<RewardPackageOptions>> GetRewardPackageByIdAsync(int id);

        Task<Result<int>> DeleteRewardPackageByIdAsync(int id);
    }
}

