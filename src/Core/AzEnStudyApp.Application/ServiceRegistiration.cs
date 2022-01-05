using System.Dynamic;
using System.Reflection;
using AzEnStudyApp.Application.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AzEnStudyApp.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationRegistiration(this IServiceCollection service)
        {
            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            service.AddMediatR(assembly);
        

        }
    }
}