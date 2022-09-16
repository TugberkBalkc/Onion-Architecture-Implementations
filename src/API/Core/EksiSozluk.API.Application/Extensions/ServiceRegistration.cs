using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Utilities.Pipelines.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            services.AddScoped(typeof(EntryBusinessRules));
            services.AddScoped(typeof(EntryCommentBusinessRules));
            services.AddScoped(typeof(OperationClaimBusinessRules));
            services.AddScoped(typeof(RoleBusinessRules));
            services.AddScoped(typeof(UserBusinessRules));

            services.AddMediatR(assemblies);

            services.AddAutoMapper(assemblies);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
