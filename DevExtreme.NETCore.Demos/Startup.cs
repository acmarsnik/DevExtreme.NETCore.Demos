using DevExtreme.NETCore.Demos.Models.Demos;
using DevExtreme.NETCore.Demos.Models.Northwind;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using DevExtreme.NETCore.Demos.Models.Menu;
using DevExtreme.NETCore.Demos.Hubs;
using DevExtreme.NETCore.Demos.Models.SignalR;

namespace DevExtreme.NETCore.Demos {
    public class Startup {
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            MvcDemosStore.Initialize(env.ContentRootPath);
            Menu.Initialize(MvcDemosStore.Categories);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services
                .AddMemoryCache()
                .AddSession(s => {
                    s.CookieName = "DevExtreme.NETCore.Demos";
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services
               .AddLogging()
               .AddDbContext<NorthwindContext>(ConfigureNorthwindContext);

            services.AddSignalR();
            services.AddScoped<LiveUpdateSignalRHub>();
            services.AddSingleton<StockTicker>();

#if DB_LOCALDB
            services.AddEntityFrameworkSqlServer();
#endif

#if DB_SQLITE
            services.AddEntityFrameworkSqlite();
#endif
        }

        static void ConfigureNorthwindContext(IServiceProvider serviceProvider, DbContextOptionsBuilder options) {
            var hosting = serviceProvider.GetRequiredService<IHostingEnvironment>();
#if DB_LOCALDB
            var dbPath = Path.Combine(hosting.ContentRootPath, "Northwind.mdf");
            var connectionString = $@"Data Source=(localdb)\devextreme; AttachDbFileName={dbPath}; Integrated Security=True; MultipleActiveResultSets=True; App=EntityFramework";
            options.UseSqlServer(connectionString);
#endif

#if DB_SQLITE
            var dbPath = Path.Combine(hosting.ContentRootPath, "Northwind.sqlite");
            options.UseSqlite("Data Source=" + dbPath);
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider) {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "DataGrid", action = "Overview" }
                );
            });

            app.UseSignalR(routes => {
                routes.MapHub<LiveUpdateSignalRHub>("liveUpdateSignalRHub");
            });

        }
    }
}
