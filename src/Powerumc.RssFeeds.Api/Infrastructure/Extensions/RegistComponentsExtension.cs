using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Powerumc.RssFeeds.Api.Infrastructure.Extensions
{
    public static class RegistComponentsExtension
    {
        public static void AddRegistComponents(this IServiceCollection serviceCollection)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute(typeof(RegisterAttribute)) is RegisterAttribute registerAttribute)
                    {
                        System.Console.WriteLine($"RegistrationType: {registerAttribute.RegistrationType}, {type}");
                        serviceCollection.AddSingleton(registerAttribute.RegistrationType, type);
                    }
                }
            }
        }
    }
}