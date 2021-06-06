using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PF6_Team4_Core.Data;
using PF6_Team4_Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Services;
using PF6_Team4_Core.Services.VMServices;

namespace PF6_Team4_Core.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IRewardPackageServices, RewardPackageService>();
            services.AddScoped<IProjectServices, ProjectService>();
            services.AddScoped<IUserServiceAlkiviadis, UserService>();
            services.AddScoped<IUserVMService, UserVMService>();
            services.AddScoped<IProjectVMService, ProjectVMService>();
            services.AddScoped<IUserLoginService, UserLogInService>();




            return services;
        }
    }
}
