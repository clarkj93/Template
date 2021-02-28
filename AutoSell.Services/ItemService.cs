using AutoSell.Data.Context;
using AutoSell.Data.Enumerations.ItemStatus;
using AutoSell.Data.Models;
using AutoSell.Services.Repositories;
using System.Linq;

namespace AutoSell.Services
{
    public class ItemService : ModelService<Item>, IItemRepository
    {
        #region Constructors
        /// <summary>
        /// The service used to query the Items table
        /// </summary>
        /// <param name="autoSellContext"></param>
        public ItemService(AutoSellContext autoSellContext) : base(autoSellContext, autoSellContext.Items)
        { }
        #endregion

        #region Methods
        public IQueryable<Item> GetByStatus(ItemStatusType itemStatusType)
        {
            return GetAll().Where(x => x.ItemStatusId == itemStatusType.Id);
        }
        #endregion
    }
}
