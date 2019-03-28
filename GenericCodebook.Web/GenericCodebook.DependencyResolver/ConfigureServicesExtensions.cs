using GenericCodebook.DependencyResolver.CodeBookResolvers;
using GenericCodebook.Domain.Common.Interfaces;
using GenericCodebook.Domain.Services.Implementations;
using GenericCodebook.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCodebook.DependencyResolver
{
    public static class ConfigureServicesExtensions
    {
        /// <summary>
        /// Use this method for configuring and registering all custom services for all projects in solution, so that there is a clean separation of dependencies between projects
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <returns>IServiceCollection wtih all custom services registered</returns>
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration Configuration)
        {
            //Register dependencies
            services.AddScoped<ICodeBookDependencyResolver, CodeBookDependencyResolver>();
            services.AddScoped<ISuggestionDependencyResolver, SuggestionDependencyResolver>();
            services.AddScoped<ICodebookTestService, CodebookTestService>();

            return services;
        }
    }
}
