using AutoSell.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoSell.Tests.Services.TestDataContext
{
    public static class SeedData
    {
        #region Methods
        /// <summary>
        /// Used for providing seed data for all foreign key associations needed by the principal entities
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder available in EntityFrameworkCore 3.1</param>
        public static void SeedForeignKeyDependencies(this ModelBuilder modelBuilder)
        {
            #region ItemsStatus
            modelBuilder.Entity<ItemStatus>()
                .HasData(
                new ItemStatus
                {
                    Id = 1,
                    Status = "Available",
                    Created = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                },
                new ItemStatus
                {
                     Id = 2,
                     Status = "Not Available",
                     Created = DateTime.UtcNow,
                     LastUpdated = DateTime.UtcNow
                },
                new ItemStatus
                {
                    Id = 3,
                    Status = "Sold",
                    Created = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                });
            #endregion 
        }

        /// <summary>
        /// Used for providing seed data for all principal entities which may or may not have foriegn key dependencies
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder available in EntityFrameworkCore 3.1</param>
        public static void SeedPrincipalEntities(this ModelBuilder modelBuilder)
        {
            #region Items
            modelBuilder.Entity<Item>()
                .HasData(
                new Item
                {
                    Id = 1,
                    ItemStatusId = 1,
                    Created = DateTime.UtcNow,
                    LastUpdated = DateTime.UtcNow
                });
            #endregion
        }
        #endregion
    }
}
