using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Configurations;
using Utconnect.Teacher.Models;
using Utconnect.Teacher.Services.Abstract;
using Utconnect.Teacher.Services.Implementations;

namespace Utconnect.Teacher
{
    public static class ConfigureServices
    {
        public static void AddTeacherService(
            this IServiceCollection services,
            IConfiguration configuration,
            string? configurationPath = null)
        {
            services.AddConfiguration<TeacherConfig>(configuration, configurationPath);
            services.AddHttpClient<ITeacherService, TeacherService>(configureClient =>
            {
                string? configPath = configuration.GetSection(configurationPath ?? nameof(TeacherConfig)).Value;
                if (configPath != null)
                {
                    configureClient.BaseAddress = new Uri(configPath);
                }
            });
            services.AddTransient<ITeacherService, TeacherService>();
        }
    }
}