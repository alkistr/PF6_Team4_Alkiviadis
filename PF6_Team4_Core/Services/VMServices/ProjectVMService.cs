using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.ViewModels;
using System.Linq;



namespace PF6_Team4_Core.Services.VMServices
{
    public class ProjectVMService : ProjectVMServiceInterface
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
            List<RewardPackageOptions> rewardpackages = _context
                .RewardPackages
                .ToList(_rewardpackage => _rewardpackage.ProjectId == id);


            return new Result<List<RewardPackageOptions>>
            {
                Data = rewardpackages
            };
        }


        public Result<ProjectOptions> GetProjectVMByIdAsync(int id)
        {
            var viewp = _context
                .Projects
                .SingleOrDefault(_project => _project.ProjectId == id);
            
            ProjectOptions viewprojectoptions = new() 
            {
                ProjectId = viewp.ProjectId, 
                category = viewp.category,
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
            
            ProjectOptions project = GetProjectVMByIdAsync(id);
            List<RewardPackageOptions> rewardpackages = GetprojectrewardpackagesVM(id);

            ProjectVM projectview = new()
            { 
                ProjectId = project.ProjectId,
                rewardpackageProjectVM = rewardpackages
            };
                  
                        
            return new Result<ProjectVM>
            {
                Data = projectview
            };

        }
    }
}
