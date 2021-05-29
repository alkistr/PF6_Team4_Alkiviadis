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
        public Task<Result<RewardPackage>> CreateRewardPackageAsync(RewardPackageOptions rewardpackageoptions)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeleteRewardPackageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<RewardPackage>>> GetRewardPackageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<RewardPackage>> GetRewardPackageByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
