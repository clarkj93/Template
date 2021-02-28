using AutoSell.Data.Models;
using AutoSell.Data.Models.Base;
using AutoSell.Services;
using AutoSell.Services.Repositories;
using AutoSell.Services.Repositories.Base;
using AutoSell.Tests.Services.TestDataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AutoSell.Tests.Services
{
    public class ModelServiceTests
    {
        #region Properties
        DataAccess DataAccess => new DataAccess();
        #endregion

        public void GetAll_ShouldReturnMoreThanZero<T>() where T : class, IBaseEntity
        {
            //Arrange
            using UnitTestContext autoSellContext = new UnitTestContext(DataAccess.Options);

            DbSet<T> table = autoSellContext.Set<T>();

            ISearchable<T> repository = new ModelService<T>(autoSellContext, table);

            //Act
            var actual = repository.GetAll().ToList();

            //Assert
            Assert.True(actual.Count > 0);
        }

        public void GetById_ShouldReturnNotNull<T>() where T : class, IBaseEntity
        {
            //Arrange
            using UnitTestContext autoSellContext = new UnitTestContext(DataAccess.Options);

            DbSet<T> table = autoSellContext.Set<T>();

            int existingId = table.FirstOrDefault().Id;

            ISearchable<T> repository = new ModelService<T>(autoSellContext, table);

            //Act
            var actual = repository.GetById(existingId);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
