using System.Reflection;
using AzEnStudyApp.Application.Interfaces.Repository;
using AzEnStudyApp.Infrastructure.AppContext;
using AzEnStudyApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzEnStudyApp.Infrastructure
{
    public static class ServiceRegistiration
    {

        public static void AddPersistenceServiceRegistiration(this IServiceCollection  service)
        {

            service.AddTransient<IQuizRepository, QuizRepository>();
            



        }
    }
}