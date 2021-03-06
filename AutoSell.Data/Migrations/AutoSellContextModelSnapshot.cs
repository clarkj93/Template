﻿// <auto-generated />
using System;
using AutoSell.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoSell.Data.Migrations
{
    [DbContext(typeof(AutoSellContext))]
    partial class AutoSellContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AutoSell.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemStatusId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 1, 15, 13, 42, 48, 478, DateTimeKind.Utc).AddTicks(3162),
                            ItemStatusId = 1,
                            LastUpdated = new DateTime(2021, 1, 15, 13, 42, 48, 478, DateTimeKind.Utc).AddTicks(4185)
                        });
                });

            modelBuilder.Entity("AutoSell.Data.Models.ItemStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemsStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(2618),
                            LastUpdated = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(3593),
                            Status = "Available"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4409),
                            LastUpdated = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4412),
                            Status = "Not Available"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4414),
                            LastUpdated = new DateTime(2021, 1, 15, 13, 42, 48, 475, DateTimeKind.Utc).AddTicks(4415),
                            Status = "Sold"
                        });
                });

            modelBuilder.Entity("AutoSell.Data.Models.Item", b =>
                {
                    b.HasOne("AutoSell.Data.Models.ItemStatus", "ItemStatus")
                        .WithMany()
                        .HasForeignKey("ItemStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
