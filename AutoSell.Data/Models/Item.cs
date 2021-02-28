using AutoSell.Data.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSell.Data.Models
{
    public class Item : IBaseEntity
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("ItemStatus")]
        public int ItemStatusId { get; set; }

        #region Navigation_Properties
        public ItemStatus ItemStatus { get; set; }
        #endregion
        #endregion
    }
}
