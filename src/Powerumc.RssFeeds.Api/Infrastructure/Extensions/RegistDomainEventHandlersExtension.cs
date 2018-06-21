using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Powerumc.RssFeeds.Domain;
using Powerumc.RssFeeds.Domain.Events;
using Powerumc.RssFeeds.Events;
using Powerumc.RssFeeds.Services.Handlers;

namespace Powerumc.RssFeeds.Api.Infrastructure.Extensions
{
    public static class RegistDomainEventHandlersExtension
    {
        public static IServiceCollection AddRegistDomainEventHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEventBus, EventBus>();

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
                        Console.WriteLine($"RegistrationDomainEventHandler: {assemblyType.Name}");

                        serviceCollection.AddSingleton(assemblyType);
                    }
                }
            }

            return serviceCollection;
        }
    }
}