using System.IO;
using System.Linq;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Powerumc.RssFeeds.Api.Infrastructure.Extensions;
using Powerumc.RssFeeds.Database;
using Powerumc.RssFeeds.Events;
using Swashbuckle.AspNetCore.Swagger;

namespace Powerumc.RssFeeds.Api.Infrastructure
{
    public class PowerumcRssFeedsConfigurationsOptions
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IHostingEnvironment _env;

        public PowerumcRssFeedsConfigurationsOptions(IServiceCollection serviceCollection,
            IHostingEnvironment env)
        {
            _serviceCollection = serviceCollection;
            _env = env;
        }

        public PowerumcRssFeedsConfigurationsOptions AddDefault()
        {
            _serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            _serviceCollection.AddSingleton<IRssFeedsDbContextFactory, RssFeedsDbContextFactory>();

            return this;
        }
        
        public PowerumcRssFeedsConfigurationsOptions AddDataProtection()
        {
            _serviceCollection.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(_env.ContentRootPath, "../DataProtection-Keys")))
                .DisableAutomaticKeyGeneration();
            
            return this;
        }

        public PowerumcRssFeedsConfigurationsOptions AddDbContext()
        {
//            _serviceCollection.AddDbContext<RssFeedsDbContext>(options =>
//                {
//                    options.UseInMemoryDatabase("rssfeeds-db");
//                });
            
            return this;
        }

        public PowerumcRssFeedsConfigurationsOptions AddSwagger()
        {
            _serviceCollection.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(o => o.FullName);
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Powerumc RssFeeds",
                    Version = "v1",
                    License = new License {Name = "MIT", Url = ""},
                    Contact = new Contact {Email = "powerumc@gmail.com", Name = "Junil Um", Url = "http://blog.powerumc.kr"}
                });

                Directory.GetFiles(PlatformServices.Default.Application.ApplicationBasePath, "*.xml")
                    .ToList()
                    .ForEach(filename =>
                    {
                        options.IncludeXmlComments(filename);
                    });
            });

            return this;
        }

        public PowerumcRssFeedsConfigurationsOptions AddCors()
        {
            _serviceCollection.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            return this;
        }

        public PowerumcRssFeedsConfigurationsOptions AddTraceId()
        {
            _serviceCollection.AddTraceId();

            return this;
        }

        public PowerumcRssFeedsConfigurationsOptions AddRegistComponents()
        {
            _serviceCollection.AddRegistComponents();

            return this;
        }

        public void AddRegistDomainEventHandlers()
        {
            _serviceCollection.AddRegistDomainEventHandlers();
        }
    }
}