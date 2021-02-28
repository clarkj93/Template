using AutoSell.Data.Models;
using AutoSell.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoSell.Data.Context
{
    public class AutoSellContext : DbContext
    {
        #region Properties
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStatus> ItemsStatus { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// The database context used to access AutoSell data
        /// </summary>
        /// <param name="dbContextOptions">Db instance configuration</param>
        public AutoSellContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Configure the DatabaseContext to use the required database instance
        /// </summary>
        /// <param name="optionsBuilder">Context configuration</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        /// <summary>
        /// Override used to seed the database and add initial test data
        /// </summary>
        /// <param name="modelBuilder">Model to seed with data</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed primary data


            // Seed test data
            modelBuilder.SeedForeignKeyDependencies();
            modelBuilder.SeedPrincipalEntities();
        }

        /// <summary>
        /// Override save changes to ensure entities have correct timestamps added to them when entities are added or modified
        /// </summary>
        /// <returns>Change saved by the save manager</returns>
        public override int SaveChanges()
        {
            EnsureEntityTimestampIntegrity();

            return base.SaveChanges();
        }

        /// <summary>
        /// Ensure that entities have correct timestamps on them when they are added or modified
        /// </summary>
        protected void EnsureEntityTimestampIntegrity()
        {
            IEnumerable<EntityEntry> entities = from entity in ChangeTracker.Entries()
                                                where (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                                                // && entity is IBaseEntity
                                                select entity;

            // Ensure entity has a relevant timestamps when it is added
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((IBaseEntity)entity.Entity).Created = DateTime.UtcNow;
                    ((IBaseEntity)entity.Entity).LastUpdated = DateTime.UtcNow;
                }

                if (entity.State == EntityState.Modified)
                {
                    ((IBaseEntity)entity.Entity).LastUpdated = DateTime.UtcNow;
                }
            }
        }
        #endregion
    }
}
