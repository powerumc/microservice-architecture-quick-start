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

namespace Powerumc.RssFeeds.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddApiVersioning();

            services.AddRssFeedsConfigurations(options =>
            {
                options.AddDefault()
                    .AddDbContext()
                    .AddCors()
                    .AddSwagger()
                    .AddTraceId()
                    .RegistComponents();
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

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseRssFeedsConfigurationsOptions();

            feedsDbContextFactory.Seed();

            using (var dbContext = feedsDbContextFactory.Create())
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("***" + dbContext.RssFeeds.Count());
                dbContext.RssFeeds.ToList().ForEach(o => Console.WriteLine($"*** {o.Id}, {o.Title}"));
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
    }
}
