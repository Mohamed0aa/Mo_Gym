using Microsoft.Extensions.Logging;
using Mo_Talabat_Core_Domain.Contract;

namespace Mo_Api_Talabat.Extensions
{
    public static class InitializerExtensions
    {
        public static async Task<WebApplication> InitializerStoreContext(this WebApplication app)
        {
            using var Scope =  app.Services.CreateAsyncScope();
            var Services=Scope.ServiceProvider;
            var StorContextInitializer = Services.GetRequiredService<IStoreContextInitializer>();

            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {
                await StorContextInitializer.InitializeAsync();
                await StorContextInitializer.SeedAsync();
            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "There Errors in seeding data or initialize data base");
            }
            return app;
        }
    }
}
