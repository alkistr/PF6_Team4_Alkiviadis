using Microsoft.Extensions.Logging;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.Models.Options;
using PF6_Team4_Core.Options;
using PF6_Team4_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Services.VMServices
{
    public class UserVMService : IUserVMService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserVMService> _logger;

        public UserVMService(IApplicationDbContext context, ILogger<UserVMService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Result<List<BackerUserProjectOptions>> GetUserbackerprojectsVM(int id)
        {
            List<BackerUserProject> backerprojects = _context
                            .BackerUserProjects
                            .Where(_backerprojects => _backerprojects.ProjectId == id)
                            .ToList();

            var backerprojectsoptions = new List<BackerUserProjectOptions>();

            foreach (BackerUserProject bpoptions in backerprojects)
            {
                backerprojectsoptions.Add(new BackerUserProjectOptions() 
                { 
                    ProjectId = bpoptions.ProjectId,
                    UserId = bpoptions.UserId,
                    AmountDonated = bpoptions.AmountDonated
                });
            }
            
            return new Result<List<BackerUserProjectOptions>>
            {
                Data = backerprojectsoptions
            };
        }

        public Result<List<ProjectOptions>> GetUsercreatorprojectsVM(int id)
        {
            List<Project> creatorsprojects = _context
                                        .Projects
                                        .Where(_project => _project.ProjectId == id)
                                        .ToList();



            var creatorsprojectsoptions = new List<ProjectOptions>();

            foreach (Project cpoptions in creatorsprojects)
            {
                creatorsprojectsoptions.Add(new ProjectOptions() 
                {
                    ProjectOptionsId = cpoptions.ProjectId,
                    //category = cpoptions.category,
                    CurrentAmount = cpoptions.CurrentAmount,
                    Description = cpoptions.Description,
                    Title = cpoptions.Title,
                    TotalAmount = cpoptions.TotalAmount
                });
            }

            return new Result<List<ProjectOptions>>
            {
                Data = creatorsprojectsoptions
            };
        }

        public Result<UserOptions> GetUserVMByIdAsync()
        {
            int id = _context
                        .UsersLoggedIn
                        .OrderByDescending(x => x.UserId)
                        .First()
                        .UserId;

            var viewU = _context
                .Users
                .SingleOrDefault(_user => _user.UserId == id);

            UserOptions viewuseroptions = new()
            {
                UserOptionsId = viewU.UserId,
                FirstName = viewU.FirstName,
                LastName = viewU.LastName,
                Email = viewU.Email
                
            };

            return new Result<UserOptions>
            {
                Data = viewuseroptions
            };
        }


        public Result<UserVM> CreateUserVM(int id)
        {

            var uservm = GetUserVMByIdAsync();
            var projectsofcreatoruser = GetUsercreatorprojectsVM(id); 
            var backeruserproject  = GetUserbackerprojectsVM(id);

            UserVM userview = new()
            {
                UserVMId = uservm.Data.UserOptionsId,
                FirstName = uservm.Data.FirstName,
                projectsUserVM = projectsofcreatoruser.Data,
                backeruserprojectsUserVM = backeruserproject.Data
            };


            return new Result<UserVM>
            {
                Data = userview
            };

        }

    }
}
