using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandlers;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Bus;
using ClearArch.Infra.Data.Context;
using ClearArch.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)        
        {
           
            services.AddScoped<ICourseService, CourseService>();
           
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            services.AddScoped<UniversityDBContext>();
        }
    }
}
