using LibTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibTech.Infrastructure.Services
{
    public static class ServicesExtension
    {
        public static void AddDatabaseConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<LibTechContext>(options => options.UseSqlServer("name=ConnectionStrings:LibTechDatabase"));
        }
    }
}
