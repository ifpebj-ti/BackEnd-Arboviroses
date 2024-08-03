using arbovirose.Infra.Database.Entityframework;
using Microsoft.EntityFrameworkCore;

namespace arbovirose.WebApi.Config
{
    public static class DbContext
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArboviroseContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
