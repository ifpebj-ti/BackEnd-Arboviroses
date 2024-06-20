using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Application.Usecases.InfoHome;
using arbovirose.Infra.Database.Entityframework.Repositories;
using arbovirose.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace arbovirose.Infra.Ioc
{
    public class InfoHomeDependency
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<AddInfoHome>();
            service.AddScoped<IInfoHomeRepository, InfoHomeRepository>();
            service.AddScoped<IUploadService, UploadService>();
        }
    }
}
