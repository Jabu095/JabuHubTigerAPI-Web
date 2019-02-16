using JabulaniHubTiger.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Repository.Tests.Helpers
{
    public static class ContextFactory
    {
        public static ApplicationDbContext CreateContext(bool withData)
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ApplicationDb")
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;

        }
    }
}
