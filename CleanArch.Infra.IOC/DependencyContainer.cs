using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using ClearArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)        {
           
            services.AddScoped<ICourseService, CourseService>();
           
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
