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
        Task<Result<List<Project>>> GetAllProjectsAsync();
        Task<Result<Project>> CreateProjectAsync(int? userId , CreateProjectOptions createProjectOptions);

        Task<Result<Project>> GetProjectByIdAsync(int? id);
        Task<bool> UpdateProjectAsync(int? userId,int? projectId, UpdateProjectOptions updadeProjectOptions);
        Task<IQueryable<Project>> SearchProjectAsync(SearchProjectOptions searchProjectOptions);

    }
}
