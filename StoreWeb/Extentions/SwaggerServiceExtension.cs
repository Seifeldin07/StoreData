using Microsoft.OpenApi.Models;

namespace Store.Web.Extentions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "John Walker",
                        Email ="Jonsemail@gmail.com",
                        Url = new Uri("https://localhost:7017")
                    }
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer Scheme. Example: \"Authorization: Bearer {Token}\"",
                    Name ="Authorization",
                    In= ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id ="bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition("bearer",securityScheme);

                var securityRequirements = new OpenApiSecurityRequirement
                {
                    {securityScheme,new[]{"bearer"} }
                };
                options.AddSecurityRequirement(securityRequirements);
            });
            return services;
        }
    }
}
