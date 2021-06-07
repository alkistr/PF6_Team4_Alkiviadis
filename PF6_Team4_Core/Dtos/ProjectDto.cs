using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Dtos
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        [ForeignKey("CreatorId")]
        public int CreatorId { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public Category category { get; set; } = Category.Software;
        public List<RewardPackage> ProjectRewardPackages { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<Media> Medias { get; set; }
        public DateTime Createdate { get; set; } = DateTime.Now;

        public static ProjectDto MapFromProject(Project project)
        {
            return new ProjectDto
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                CreatorId = project.CreatorId,
                category = project.category
            };
        }


        public static List<ProjectDto> MapFromProject(List<Project> projects)
        {
            var result = new List<ProjectDto>();

            foreach (var project in projects)
            {
                result.Add(new ProjectDto
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Description = project.Description,
                    CreatorId = project.CreatorId,
                    category = project.category
                });
            }

            return result;
        }

    }
}


