using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    /// <summary>
    /// Persistence katmanı için servisleri kayıt eder.
    /// </summary>
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SoftResumeConnectionString")));

            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<IProgrammingLanguageTechnologyRepository, ProgrammingLanguageTechnologyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUserSocialMediaAddressRepository, UserSocialMediaAddressRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }
    }
}
