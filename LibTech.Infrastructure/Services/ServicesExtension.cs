using LibTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibTech.Infrastructure.Services
{
    public static class ServicesExtension
    {
        public static void AddDatabaseConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<LibTechContext>(options => options.UseSqlServer("name=ConnectionStrings:LibTechDatabase",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ServicesExtension).GetTypeInfo().Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                }));
        }
    }
}
