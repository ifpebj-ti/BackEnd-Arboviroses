using arbovirose.Application.Repositories;
using arbovirose.Application.Usecases.Profile;
using arbovirose.Infra.Database.Entityframework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace arbovirose.Infra.Ioc
{
    public class ProfileDependency
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<CreateProfile>();
            service.AddScoped<IProfileRepository, ProfileRepository>();
        }
    }
}
