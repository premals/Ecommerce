﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApi.DbModel;

namespace ProductApi.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20210403095908_Product")]
    partial class Product
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductApi.DbModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sku");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Color = "Black", Name = "Pendrive", Price = 50m, Sku = "pnBlack" },
                        new { Id = 2, Color = "Blue", Name = "Harddisk", Price = 80m, Sku = "hdBlue" },
                        new { Id = 3, Color = "Red", Name = "Mouse", Price = 30m, Sku = "pnRed" },
                        new { Id = 4, Color = "green", Name = "Ram", Price = 40m, Sku = "rmGreen" },
                        new { Id = 5, Color = "Black", Name = "Keyboard", Price = 10m, Sku = "blackKeyboard" },
                        new { Id = 6, Color = "yellow", Name = "Lancable", Price = 70m, Sku = "lnYellow" },
                        new { Id = 7, Color = "Black", Name = "battery", Price = 40m, Sku = "batteryBlack" },
                        new { Id = 8, Color = "Black", Name = "dockStation", Price = 50m, Sku = "dockBlack" },
                        new { Id = 9, Color = "Black", Name = "Router", Price = 20m, Sku = "RouterBlack" },
                        new { Id = 10, Color = "Black", Name = "Laptop Stand", Price = 5m, Sku = "standBlack" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
