﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Persistence;

#nullable disable

namespace Store.Persistence.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220709182914_AddTestData")]
    partial class AddTestData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "ShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductShop");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"),
                            ShopId = new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d")
                        },
                        new
                        {
                            ProductId = new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"),
                            ShopId = new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d")
                        });
                });

            modelBuilder.Entity("Store.Domain.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("743a64ef-bccb-4e6d-8543-4a65bc0fe846"),
                            Description = "Vegetables",
                            ProductName = "Tomato"
                        },
                        new
                        {
                            ProductId = new Guid("09133c5e-9733-40f9-bed5-d485f27e448e"),
                            Description = "Vegetables",
                            ProductName = "Potato"
                        });
                });

            modelBuilder.Entity("Store.Domain.Shop", b =>
                {
                    b.Property<Guid>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OpeningTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShopAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("ShopId");

                    b.HasIndex("ShopId")
                        .IsUnique();

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopId = new Guid("18dd943b-73be-47c9-8a89-e440accb4a1d"),
                            ClosingTime = new DateTime(1, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            OpeningTime = new DateTime(2015, 7, 21, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ShopAddress = "Minsk",
                            ShopName = "Sosedi"
                        });
                });

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.HasOne("Store.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Domain.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
