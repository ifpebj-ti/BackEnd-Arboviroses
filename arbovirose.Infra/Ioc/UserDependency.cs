using arbovirose.Application.Repositories;
using arbovirose.Application.Usecases.User;
using arbovirose.Infra.Database.Entityframework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace arbovirose.Infra.Ioc
{
    public class UserDependency
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<CreateUser>();
            services.AddScoped<DeactivateUser>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
