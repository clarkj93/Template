using AutoSell.Data.Enumerations;
using AutoSell.Data.Enumerations.ItemStatus;
using AutoSell.Data.Models;
using AutoSell.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AutoSell.Api.Controllers
{
    [ApiController]
    [Route("item")]
    public class ItemController : ControllerBase
    {
        #region Properties
        private IItemRepository ItemRepository { get; init; }
        #endregion

        #region Constructors
        public ItemController(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }
        #endregion

        #region Methods
        [HttpGet]
        [Route("")]
        public IEnumerable<Item> GetAll()
        {
            return ItemRepository.GetAll().AsEnumerable();
        }

        [HttpGet]
        [Route("{id}")]
        public Item GetById(int id)
        {
            return ItemRepository.GetById(id);
        }

        [HttpGet]
        [Route("status/{id}")]
        public IEnumerable<Item> GetByStatus(int id)
        {
            return ItemRepository.GetByStatus(Enumeration.GetAll<ItemStatusType>().Where(x => x.Id == id).FirstOrDefault());
        }
        #endregion


    }
}
