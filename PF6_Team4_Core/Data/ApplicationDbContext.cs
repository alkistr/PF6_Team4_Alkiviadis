using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PF6_Team4_Core.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<UserLoggedIn> UsersLoggedIn { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<RewardPackage> RewardPackages { set; get; }
        DbSet<BackerUserProject> IApplicationDbContext.BackerUserProjects { set; get; }
        DbSet<ProjectRewardPackage> IApplicationDbContext.ProjectRewardPackages { set; get; }
        DbSet<UserLoggedIn> IApplicationDbContext.UsersLoggedIn { set; get; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
