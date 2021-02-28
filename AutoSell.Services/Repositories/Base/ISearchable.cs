using System;
using System.Linq;

namespace AutoSell.Services.Repositories.Base
{
    public interface ISearchable<T>
    {
        public IQueryable<T> GetAll();

        public T GetById(int id);
    }
}
