using JabulaniHubTiger.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniHubTiger.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Booking>()
                .HasKey(x => new { x.BicycleId, x.BicycleUserId });

            builder.Entity<Booking>()
                .HasOne(x => x.Bicycle)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.BicycleId);

            builder.Entity<Booking>()
               .HasOne(x => x.BicycleUser)
               .WithMany(x => x.Bookings)
               .HasForeignKey(x => x.BicycleUserId);

        }

        public DbSet<ORM.Bicycle> Bicycles { get; set; }
        public DbSet<BicycleUser> BicycleUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
