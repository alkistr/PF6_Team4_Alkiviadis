using PF6_Team4_Core.Dtos;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Models.Options.ProjectOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IProjectServices
    {
        Task<Result<List<ProjectDto>>> GetAllProjectsAsync();
        Task<Result<ProjectDto>> CreateProject(CreateProjectOptions createProjectOptions);
        Task<Result<ProjectDto>> GetProjectByIdAsync(int id);
        Task<Result<int>> DeleteProjectByIdAsync(int id);
        Task<Result<int>> UptadeProjectAsync(int userId,int projectId, UpdateProjectOptions updadeProjectOptions);
        Task<Result<List<ProjectDto>>> SearchProjectAsync(SearchProjectOptions searchProjectOptions);



    }
}

