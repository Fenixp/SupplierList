using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using SupplierList.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SupplierList.Data.Model;
using SupplierList.Web.Infrastructure;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Business.Interface.Features.Commands;
using SupplierList.Business.Features.Commands;

namespace SupplierList
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CompositionRootConfig.RegisterAll(services, Configuration);

            /*DbContextOptionsBuilder<SupplierContext> builder = new DbContextOptionsBuilder<SupplierContext>()
                .UseSqlServer(Configuration["ConnectionString"], b => b.MigrationsAssembly("SupplierList.Web"));
            

            using (SupplierContext context = new SupplierContext(builder.Options))
            {
                AddGroupsFromSeedCommandHandler command = new AddGroupsFromSeedCommandHandler(context);
            }*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            ICommandHandler<AddGroupsFromSeedCommand> addGroupsFromSeedCommand)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            addGroupsFromSeedCommand.Handle(new AddGroupsFromSeedCommand { SeedFileLocation = Configuration["DataSeedPath"] });        
        }
    }
}
