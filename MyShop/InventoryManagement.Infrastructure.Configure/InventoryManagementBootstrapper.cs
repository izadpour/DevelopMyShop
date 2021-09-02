using System;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using InventoryManagement.Domian.InventoryAgg;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repository;
using InventoryManagementApplication;
using InventoryManagementApplication.Contracts.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure.Configure
{
    public class InventoryManagementBootstrapper

    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        } 
    }
}
