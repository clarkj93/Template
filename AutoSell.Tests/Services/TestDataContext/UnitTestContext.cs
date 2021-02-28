using AutoSell.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoSell.Tests.Services.TestDataContext
{
    /// <summary>
    /// Data context used for unit testing purposes
    /// </summary>
    public class UnitTestContext : AutoSellContext
    {
        #region Contructors
        /// <summary>
        /// Accepts db instance configurations
        /// </summary>
        /// <param name="dbContextOptions">Db instance configuration</param>
        public UnitTestContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        #endregion

        #region Methods
        /// <summary>
        /// Override used to seed the database and add initial test data
        /// </summary>
        /// <param name="modelBuilder">Model to seed with data</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.SeedForeignKeyDependencies();
            modelBuilder.SeedPrincipalEntities();
        }
        #endregion
    }
}
