using AutoSell.Data.Enumerations.ItemStatus;
using AutoSell.Data.Models;
using AutoSell.Services.Repositories.Base;
using System.Linq;

namespace AutoSell.Services.Repositories
{
    public interface IItemRepository : ISearchable<Item>
    {
        public IQueryable<Item> GetByStatus(ItemStatusType itemStatusType);
    }
}
