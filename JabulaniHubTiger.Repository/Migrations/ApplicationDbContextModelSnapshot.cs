﻿// <auto-generated />
using System;
using JabulaniHubTiger.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JabulaniHubTiger.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JabulaniHubTiger.ORM.Bicycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BicyleCondition");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Model");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("JabulaniHubTiger.ORM.BicycleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdateOn");

                    b.HasKey("Id");

                    b.ToTable("BicycleUsers");
                });

            modelBuilder.Entity("JabulaniHubTiger.ORM.Booking", b =>
                {
                    b.Property<int>("BicycleId");

                    b.Property<int>("BicycleUserId");

                    b.Property<DateTime>("BookedOn");

                    b.Property<DateTime>("EndBookingOn");

                    b.HasKey("BicycleId", "BicycleUserId");

                    b.HasIndex("BicycleUserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("JabulaniHubTiger.ORM.Booking", b =>
                {
                    b.HasOne("JabulaniHubTiger.ORM.Bicycle", "Bicycle")
                        .WithMany("Bookings")
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JabulaniHubTiger.ORM.BicycleUser", "BicycleUser")
                        .WithMany("Bookings")
                        .HasForeignKey("BicycleUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
