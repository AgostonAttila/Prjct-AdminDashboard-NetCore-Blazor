using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistenceCore.Contexts;
using PersistenceCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceCore
{
    public static class ServiceRegistration
    {



        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            #endregion
        }

        public static void AddApplicationLayer2(this IServiceCollection services)
        {


        }

    }
}
