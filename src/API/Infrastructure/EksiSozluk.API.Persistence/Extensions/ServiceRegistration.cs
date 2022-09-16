using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                var connectionString = configuration["ApplicationConnectionString"];
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IEmailConfirmationRepository, EfEmailConfirmationRepository>();
            services.AddScoped<IEntryRepository, EfEntryRepository>();
            services.AddScoped<IEntryCommentRepository, EfEntryCommentRepository>();
            services.AddScoped<IEntryCommentFavoriteRepository, EfEntryCommentFavoriteRepository>();
            services.AddScoped<IEntryCommentVoteRepository, EfEntryCommentVoteRepository>();
            services.AddScoped<IEntryFavoriteRepository, EfEntryFavoriteRepository>();
            services.AddScoped<IEntryVoteRepository, EfEntryVoteRepository>();
            services.AddScoped<IOperationClaimRepository, EfOperationClaimRepository>();
            services.AddScoped<IRoleRepository, EfRoleRepository>();
            services.AddScoped<IRoleOperationClaimRepository, EfRoleOperationClaimRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            return services;
        }
    }
}
