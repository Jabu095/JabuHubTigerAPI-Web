using JabulaniHubTiger.Service.Bicycle;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Service
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IBicycleService, BicycleService>();
        }
    }
}
