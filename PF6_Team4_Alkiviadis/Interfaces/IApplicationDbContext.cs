﻿using Microsoft.EntityFrameworkCore;
using PF6_Team4_Alkiviadis.Models;
using PF6_Team4_Alkiviadis.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { set; get; }

        public DbSet<Project> Projects { set; get; }
        public DbSet<RewardPackageOptions> RewardPackages { set; get; }
        public DbSet<BackerUserProject> BackerUserProjects { set; get; }
        public DbSet<CreatorUserProject> CreatorUserProjects { set; get; }
        public DbSet<ProjectRewardPackage> ProjectRewardPackages { set; get; }

        Task<int> SaveChangesAsync();
    }
}
