using System;

namespace AutoSell.Data.Models.Base
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
