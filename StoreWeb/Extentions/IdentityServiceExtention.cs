using Microsoft.AspNetCore.Identity;

using Store.Data.Entities.IdentityEntities;
using StoreData.Contexts;

namespace Store.Web.Extentions
{
    public static class IdentityServiceExtention
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            
            builder = new IdentityBuilder(builder.UserType,builder.Services);
            
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
