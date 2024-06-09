using arbovirose.Application.Services;
using arbovirose.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace arbovirose.Infra.Ioc
{
    public class BcryptDependency
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<IBcryptService, BcryptService>();
        }
    }
}
