using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AutoSell.Tests.Services.TestDataContext
{
    public class DataAccess
    {
        #region Properties
        private SqliteConnection Connection;
        public DbContextOptions Options { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs sqlite connection in memory with UnitTestContext and its seeded data
        /// </summary>
        public DataAccess()
        {
            // Open Sqlite connection in memory
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            // Build options
            Options = new DbContextOptionsBuilder<UnitTestContext>()
                .UseSqlite(this.Connection)
                .Options;

            // Create schema in the database
            using (UnitTestContext context = new UnitTestContext(Options))
            {
                context.Database.EnsureCreated();
            }
        }
        #endregion
    }
}
