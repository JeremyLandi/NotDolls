using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace NotDolls.Migrations
{
    [DbContext(typeof(NotDollsContext))]
    [Migration("20160606163323_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotDolls.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Height");

                    b.Property<string>("InventoryDescription");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<string>("Quality");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Sold");

                    b.Property<int>("UserId");

                    b.Property<string>("Weight");

                    b.Property<int>("Year");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("NotDolls.Models.InventoryImage", b =>
                {
                    b.Property<int>("InventoryImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<int>("InventoryId");

                    b.HasKey("InventoryImageId");

                    b.ToTable("InventoryImage");
                });

            modelBuilder.Entity("NotDolls.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_Date");

                    b.Property<string>("Email");

                    b.Property<string>("Location");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });
        }
    }
}
