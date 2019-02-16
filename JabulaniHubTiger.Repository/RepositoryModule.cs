using JabulaniHubTiger.Repository.Bicycle;
using JabulaniHubTiger.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Repository
{
    public class RepositoryModule
    {
        public static void Register(IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IBicycleRepository, BicycleRepository>();
        }
    }
}
