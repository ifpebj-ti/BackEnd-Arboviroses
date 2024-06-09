using arbovirose.Application.Usecases.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace arbovirose.Infra.Ioc
{
    public class AuthDependency
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<Login>();
        }
    }
}
