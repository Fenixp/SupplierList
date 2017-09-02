using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplierList.Business.Features.Commands;
using SupplierList.Business.Interface.Features.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Data.Model;
using SupplierList.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierList.Web.Infrastructure
{
    public static class CompositionRootConfig
    {
        public static void RegisterAll(IServiceCollection services, IConfigurationRoot configuration)
        {
            RegisterSystemServices(services, configuration);
            RegisterCustomServices(services);
        }

        private static void RegisterSystemServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Add framework services.
            services.AddMvc();

            // Configure Razor lookup paths
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new FeatureLocationExpander());
            });

            services.AddDbContext<SupplierContext>
                (
                    options => options.UseSqlServer(configuration["ConnectionString"], b => b.MigrationsAssembly("SupplierList.Web"))
                );
        }

        private static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddGroupsFromSeedCommand>, AddGroupsFromSeedCommandHandler>();
        }
    }
}
