using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplierList.Business.Features.Startup.Commands;
using SupplierList.Business.Features.Suppliers.Commands;
using SupplierList.Business.Features.Suppliers.Queries;
using SupplierList.Business.Interface.Features.Startup.Commands;
using SupplierList.Business.Interface.Infrastructure;
using SupplierList.Business.Interface.Features.Suppliers.Models;
using SupplierList.Business.Interface.Features.Suppliers.Commands;
using SupplierList.Business.Interface.Features.Suppliers.Queries;
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
            // Automatic registration? Committing decorator?
            services.AddScoped<ICommandHandler<AddGroupsFromSeedCommand>, AddGroupsFromSeedCommandHandler>();
            services.AddScoped<ICommandHandler<AddSupplierCommand>, AddSupplierCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteSupplierCommand>, DeleteSupplierCommandHandler>();
            services.AddScoped<ICommandHandler<EditSupplierCommand>, EditSupplierCommandHandler>();
            services.AddScoped<IQueryHandler<IEnumerable<GroupModel>, GroupsQuery>, GroupsQueryHandler>();
            services.AddScoped<IQueryHandler<SupplierDetailModel, SupplierDetailQuery>, SupplierDetailQueryHandler>();
            services.AddScoped<IQueryHandler<IEnumerable<SupplierModel>, SuppliersQuery>, SuppliersQueryHandler>();
        }
    }
}
