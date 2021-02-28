using AutoSell.Data.Context;
using AutoSell.Data.Models.Base;
using AutoSell.Services.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoSell.Services
{
    public class ModelService<T> : ISearchable<T> where T : class, IBaseEntity
    {
        #region Properties
        private AutoSellContext AutoSellContext { get; init; }

        private DbSet<T> Table { get; init; }
        #endregion

        #region Constructors
        /// <summary>
        /// The base model service used to generically query db tables
        /// </summary>
        /// <param name="autoSellContext">The db context</param>
        /// <param name="table">The table to query</param>
        public ModelService(AutoSellContext autoSellContext, DbSet<T> table)
        {
            AutoSellContext = autoSellContext;
            Table = table;
        }
        #endregion

        #region Methods
        public IQueryable<T> GetAll()
        {
            return Table.Select(x => x);
        }

        public T GetById(int id)
        {
            return Table.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion
    }
}
