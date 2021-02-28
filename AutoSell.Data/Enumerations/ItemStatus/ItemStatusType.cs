using System.Collections.Generic;
using System.Linq;

namespace AutoSell.Data.Enumerations.ItemStatus
{
    public class ItemStatusType : Enumeration
    {
        public static readonly ItemStatusType Available = new Available(1, "Available");
        public static readonly ItemStatusType NotAvailable = new NotAvailable(2, "Not Available");
        public static readonly ItemStatusType Sold = new Sold(3, "Sold");

        public ItemStatusType(int id, string name) : base(id, name)
        { }
    }
}
