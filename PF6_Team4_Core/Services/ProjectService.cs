using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Models.Options.ProjectOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services
{
    class ProjectService : IProjectServices

    {

        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IApplicationDbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result<Project>> CreateProjectAsync(CreateProjectOptions createProjectOptions)
        {

            var newProject = new Project
            {
                ProjectName = rewardpackageoptions.RewardPackageName,
                //MaxAmountRoGetReward = rewardpackageoptions.MaxAmountRoGetReward,
                //RewardDescription = rewardpackageoptions.RewardDescription,
                //CreationDate = DateTime.Now
            };
            await _context.Projects.AddAsync(project);
        }

        public Task<Result<List<Project>>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Project>> GetProjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Project>> SearchProjectAsync(SearchProjectOptions searchProjectOptions)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Project>> UptadeProjectAsync(int userId, int projectId, UpdateProjectOptions updadeProjectOptions)
        {
            throw new NotImplementedException();
        }
    }
}
