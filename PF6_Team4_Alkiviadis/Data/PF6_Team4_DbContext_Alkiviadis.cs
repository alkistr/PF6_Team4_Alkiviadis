using Microsoft.EntityFrameworkCore;
using PF6_Team4_Alkiviadis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Data
{
    public class PF6_Team4_DbContext_Alkiviadis : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<RewardPackage> RewardPackages { set; get; }
        public DbSet<BackerRewardPackage> BackerRewardPackages { set; get; }
        public DbSet<ProjectRewardPackage> ProjectRewardPackages { set; get; }
        public DbSet<BackerUserProject> BackerUserProjects { set; get; }
        public DbSet<CreatorUserProject> CreatorUserProjects { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog= PF6_Team4_DbContext_Alkiviadis; Integrated Security = true");
        }
    }
}
