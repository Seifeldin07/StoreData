using Microsoft.EntityFrameworkCore;
using StoreData.Contexts;
using StoreRepository;

namespace StoreWeb.Helper
{
    public   class ApplySeeding
    {
        public static async Task ApplySeddingAsync(WebApplication app )
        {
            using (var scope = app.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;

                var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = Services.GetRequiredService<StoreDbContext>();

                    await context.Database.MigrateAsync();

                    await StoreContextSeed.SeedAsync(context, loggerFactory);
                }


                catch (Exception ex)
                {
                    var Logger = loggerFactory.CreateLogger<ApplySeeding>();
                    Logger.LogError(ex.Message);

                }
            }
        }


    }
}
