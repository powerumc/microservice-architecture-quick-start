using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Events;

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

            SubscribeDomainEvent(app);

            return app;

        }

        private static void SubscribeDomainEvent(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            var location = Path.GetDirectoryName(typeof(Startup).Assembly.Location);
            foreach (var filename in Directory.GetFiles(location, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(filename);
                foreach (var assemblyType in assembly.GetTypes())
                {
                    var interfaceTypes = assemblyType
                        .GetInterfaces()
                        .Where(o => o.Name == typeof(IDomainEventHandler<>).Name);

                    foreach (var type in interfaceTypes)
                    {
                        Console.WriteLine($"RegistrationDomainEvent: {type.GetGenericArguments()[0]}");
                        
                        eventBus.Subscribe(type.GetGenericArguments()[0], assemblyType);
                    }
                }
            }
        }
    }
}