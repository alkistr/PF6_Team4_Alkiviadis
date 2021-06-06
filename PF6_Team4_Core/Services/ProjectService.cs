using Microsoft.EntityFrameworkCore;
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
    public class ProjectService : IProjectServices

    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IApplicationDbContext context, ILogger<ProjectService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Project>> CreateProjectAsync(int? userId, CreateProjectOptions createProjectOptions)
        {            
            if (createProjectOptions == null)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Null options.");
            }

            if (string.IsNullOrWhiteSpace(createProjectOptions.Title) ||
              string.IsNullOrWhiteSpace(createProjectOptions.Description) ||
              createProjectOptions.CategoryId == 0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Not all required Project options provided.");
            }

            var newProject = new Project
            {
                Title = createProjectOptions.Title,
                Description = createProjectOptions.Description,
                Category = (Category)createProjectOptions.CategoryId

            };

            await _context.Projects.AddAsync(newProject);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new Result<Project>(ErrorCode.InternalServerError, "Could not save the Project.");
            }

            return new Result<Project>
            {
                Data = newProject
            };
        }

        
        public async Task<Result<List<Project>>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();

            return new Result<List<Project>>
            {
                Data = projects.Count > 0 ? projects : new List<Project>()
            };
        }



        public async Task<Result<Project>> GetProjectByIdAsync(int? id)
        {
            if (id <= 0)
            {
                return new Result<Project>(ErrorCode.BadRequest, "Id cannot be less than or equal to zero.");
            }

            var project = await _context
                .Projects
                .SingleOrDefaultAsync(_pro => _pro.ProjectId == id);

            if (project == null)
            {
                return new Result<Project>(ErrorCode.NotFound, $"Project with id #{id} not found.");
            }

            return new Result<Project>
            {
                Data = project
            };
        }


        public async Task<IQueryable<Project>> SearchProjectAsync(SearchProjectOptions searchProjectOptions)
        {
            var projects = await _context.Projects.ToListAsync();



            if (!string.IsNullOrWhiteSpace(searchProjectOptions.SearchText))
            {
                projects = projects.Where(
                        pj => pj.Title.ToLower().Contains(searchProjectOptions.SearchText.ToLower())
                              ||
                              pj.Description.ToLower()
                                  .Contains(searchProjectOptions.SearchText.ToLower()));

            }

            if (searchProjectOptions.CategoryId != 0)
            {
                projects = projects.Where(pj => searchProjectOptions.CategoryId.Contains((int)pj.Category));
            }

            return projects.AsQueryable();


        }


        public async Task<bool> UpdateProjectAsync(int? userId, int? projectId, UpdateProjectOptions updadeProjectOptions)
        {

            if (projectId == null || userId == null)
            {
                return false;
            }
            var project = GetProjectByIdAsync(projectId);

            if (!string.IsNullOrWhiteSpace(updadeProjectOptions.Description))
            {
                project.Data.Description = updadeProjectOptions.Description;
                
            }
            
            if (!string.IsNullOrWhiteSpace(updadeProjectOptions.Title))
            {
                project.Data.Title = updadeProjectOptions.Title;
                
            }

            if (updadeProjectOptions.CategoryId != 0 )
            {
               project.Data.Category = (Category) updadeProjectOptions.CategoryId;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.Message);
               return false;
            }
                
              
              return true;



        }

        
        
    }

}

