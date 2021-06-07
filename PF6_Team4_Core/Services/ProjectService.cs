using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Dtos;
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



        public async Task<Result<ProjectDto>> CreateProject(CreateProjectOptions createProjectOptions)
        {
            if (createProjectOptions == null)
            {
                return new Result<ProjectDto>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(createProjectOptions.Title) ||
              string.IsNullOrWhiteSpace(createProjectOptions.Description) ||
              (createProjectOptions.category == 0)
              )
              
            {
                return new Result<ProjectDto>(ErrorCode.BadRequest, "Not all required Project options provided.");
            }

            var projectWithTheSameTitle = await _context.Projects.SingleOrDefaultAsync(pro => pro.Title == createProjectOptions.Title);


            if (projectWithTheSameTitle != null)
            {
                return new Result<ProjectDto>(ErrorCode.Conflict, $"Product with Title #{createProjectOptions.Title} already exists.");
            }

            var newProject = new Project
            {
                Title = createProjectOptions.Title,
                Description = createProjectOptions.Description,
                category = createProjectOptions.category
                
                //MaxAmountRoGetReward = rewardpackageoptions.MaxAmountRoGetReward,
                //RewardDescription = rewardpackageoptions.RewardDescription,

            };
            await _context.Projects.AddAsync(newProject);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<ProjectDto>(ErrorCode.InternalServerError, "Could not save the Project.");
            }

            return new Result<ProjectDto>
            {
                Data = ProjectDto.MapFromProject(newProject)
            };
        }

        public async Task<Result<int>> DeleteProjectByIdAsync(int id)
        {
            var projectToDelete = await _context
               .Projects
               .SingleOrDefaultAsync(pro => pro.ProjectId == id);

            if (projectToDelete == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Project with id #{id} not found.");
            }

            _context.Projects.Remove(projectToDelete);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete project.");
            }

            return new Result<int>
            {
                Data = id
            };
        }

        public async Task<Result<List<ProjectDto>>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            return new Result<List<ProjectDto>>
            {
                Data = projects.Count > 0 ? ProjectDto.MapFromProject(projects) : new List<ProjectDto>()
            };
        }

        public async Task<Result<ProjectDto>> GetProjectByIdAsync(int id)
        {
            if (id <= 0)
            {
                return new Result<ProjectDto>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context
                .Projects
                .SingleOrDefaultAsync(pro => pro.ProjectId == id);

            if (project == null)
            {
                return new Result<ProjectDto>(ErrorCode.NotFound, $"Project with id #{id} not found.");
            }

            return new Result<ProjectDto>
            {
                Data = ProjectDto.MapFromProject(project)
            };
        }

        public async Task<Result<List<ProjectDto>>> SearchProjectAsync(SearchProjectOptions searchProjectOptions)
        {
            if (searchProjectOptions.CategoryId != 0)
            {

                var projects = await _context
                    .Projects
                    .Where(x => x.category.Equals(searchProjectOptions.CategoryId))

                    .ToListAsync();

                return new Result<List<ProjectDto>>
                {
                    Data = projects.Count > 0 ? ProjectDto.MapFromProject(projects) : new List<ProjectDto>()
                };
            }
            else
            {
                var projects = await _context
                    .Projects
                    .Where(pj => pj.Title.ToLower().Contains(searchProjectOptions.SearchText.ToLower())
                             ||
                             pj.Description.ToLower()
                                 .Contains(searchProjectOptions.SearchText.ToLower()))
                     .ToListAsync();

                return new Result<List<ProjectDto>>
                {
                    Data = projects.Count > 0 ? ProjectDto.MapFromProject(projects) : new List<ProjectDto>()
                };


            }            
        }

        public async Task<Result<int>> UptadeProjectAsync(int userId, int projectId, UpdateProjectOptions updadeProjectOptions)
        {
            if (projectId == 0 || userId == 0)
            {
                return new Result<int>(ErrorCode.NotFound, $"Project with id #{userId} not found.");
            }

            var project = await _context
                .Projects
                .SingleOrDefaultAsync(pro => pro.ProjectId == projectId);

            if (project == null)
            {
                return new Result<int>(ErrorCode.NotFound, $"Project with id #{projectId} not found.");
            }

            if (!string.IsNullOrWhiteSpace(updadeProjectOptions.Description))
            {
                project.Description = updadeProjectOptions.Description;
            }

            if (!string.IsNullOrWhiteSpace(updadeProjectOptions.Title))
            {
                project.Title = updadeProjectOptions.Title;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<int>(ErrorCode.InternalServerError, "Could not delete project.");
            }

            return new Result<int>
            {
                Data = projectId
            };



        }
    }
}
