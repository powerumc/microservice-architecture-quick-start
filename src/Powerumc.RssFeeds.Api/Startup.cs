using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Powerumc.RssFeeds.Api.Infrastructure.Extensions;
using Powerumc.RssFeeds.Database;
using Powerumc.RssFeeds.Services.Handlers;

namespace Powerumc.RssFeeds.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration,
            IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning()
                .AddHttpClient();

            services.AddRssFeedsConfigurations(_env, options =>
            {
                options.AddDefault()
                    .AddDataProtection()
                    .AddDbContext()
                    .AddCors()
                    .AddSwagger()
                    .AddTraceId()
                    .AddRegistComponents()
                    .AddRegistDomainEventHandlers();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IRssFeedsDbContextFactory feedsDbContextFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseRssFeedsConfigurationsOptions();
            feedsDbContextFactory.Seed();
            
            app.UseMvc();
        }
    }
}
