using Microsoft.Extensions.DependencyInjection;
using Mo_Talabat_Core_Application.Services;
using Share.Mapping;
using Share.Services;

namespace Mo_Talabat_Core_Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
            return services;
        }//C:\Users\Kimo Store\.nuget\packages\automapper\14.0.0\
    }
}
