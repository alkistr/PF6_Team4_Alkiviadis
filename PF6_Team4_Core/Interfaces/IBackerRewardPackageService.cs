using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IBackerRewardPackageService
    {
        Task<Result<List<BackerRewardPackage>>> GetAllRewardPackagesAsync();

        Task<Result<BackerRewardPackage>> CreateRewardPackageAsync(BackerRewardPackage backerrewardpackageoptions);
    }
}
