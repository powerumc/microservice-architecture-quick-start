using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Powerumc.RssFeeds.Api.Infrastructure.Extensions
{
    public static class ConfigurationsExtension
    {
        public static PowerumcRssFeedsConfigurationsOptions AddRssFeedsConfigurations(
            this IServiceCollection serviceCollection,
            IHostingEnvironment hostingEnvironment, 
            Action<PowerumcRssFeedsConfigurationsOptions> options)
        {
            var configurationsOptions =
                new PowerumcRssFeedsConfigurationsOptions(serviceCollection, hostingEnvironment);

            options(configurationsOptions);

            return configurationsOptions;
        }

        public static IApplicationBuilder UseRssFeedsConfigurationsOptions(
            this IApplicationBuilder app)
        {
            app.UseSwagger()
                .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "RssFeeds Api v1"))
                .UseTraceId()
                .UseCors("CorsPolicy");

            return app;

        }
    }
}