using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { set; get; }

        public DbSet<Project> Projects { set; get; }
        public DbSet<RewardPackage> RewardPackages { set; get; }
        public DbSet<BackerUserProject> BackerUserProjects { set; get; }
        public DbSet<CreatorUserProject> CreatorUserProjects { set; get; }
        public DbSet<ProjectRewardPackage> ProjectRewardPackages { set; get; }

        Task<int> SaveChangesAsync();
    }
}
