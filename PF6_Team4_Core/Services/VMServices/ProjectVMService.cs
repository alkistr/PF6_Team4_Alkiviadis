using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using System.Collections.Generic;
using System.Linq;
using PF6_Team4_Core.ViewModels;



namespace PF6_Team4_Core.Services.VMServices
{
    public class ProjectVMService : IProjectVMService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectVMService> _logger;

        public ProjectVMService(IApplicationDbContext context, ILogger<ProjectVMService> logger)
        {
            _context = context;
            _logger = logger;
        }

        

        public Result<List<RewardPackageOptions>> GetprojectrewardpackagesVM(int id)
        {
            List<RewardPackage> rewardpackages = _context
                .RewardPackages
                .Where(_rewardpackage => _rewardpackage.ProjectId == id)
                .ToList();

            var rewardpackageoptions = new List<RewardPackageOptions>();

            foreach (RewardPackage rpoptions in rewardpackages)
            {
                rewardpackageoptions.Add(new RewardPackageOptions()
                {
                    RewardPackageName = rpoptions.RewardPackageName,
                    MaxAmountRoGetReward = rpoptions.MaxAmountRoGetReward,
                    RewardDescription = rpoptions.RewardDescription
                });
            }


            return new Result<List<RewardPackageOptions>>
            {
                Data = rewardpackageoptions
            };
        }


        public Result<ProjectOptions> GetProjectVMByIdAsync(int id)
        {
            var viewp = _context
                .Projects
                .SingleOrDefault(_project => _project.ProjectId == id);
            
            ProjectOptions viewprojectoptions = new() 
            {
                ProjectOptionsId = viewp.ProjectId, 
                category = viewp.Category,
                CurrentAmount = viewp.CurrentAmount,
                TotalAmount = viewp.TotalAmount,
                Description = viewp.Description,
                Title = viewp.Title
            };

            return new Result<ProjectOptions>
            {
                Data = viewprojectoptions
            };
        }

        public Result<ProjectVM> CreateProjectVM(int id)
        {
            
            var project = GetProjectVMByIdAsync(id);
            var rewardpackages = GetprojectrewardpackagesVM(id);

            ProjectVM projectview = new()
            { 
                ProjectId = project.Data.ProjectOptionsId,
                rewardpackageProjectVM = rewardpackages.Data
            };
                  
                        
            return new Result<ProjectVM>
            {
                Data = projectview
            };

        }
    }
}
