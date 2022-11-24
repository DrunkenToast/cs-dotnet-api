using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cs_dotnet_api.dto;
using cs_dotnet_api.Models;
using cs_dotnet_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace cs_dotnet_api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _map;

        public ItemController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        [HttpGet]
        public ActionResult GetAllItems()
        {
            return Ok(_map.Map<IEnumerable<ItemReadDto>>(_repo.GetAllItems()));
        }

        [HttpGet("{id}", Name="GetItemById")]
        public ActionResult GetItemById(int id)
        {
            var item = _repo.GetItemById(id);
            if (item != null)
            {
                return Ok(_map.Map<ItemReadDto>(item));
            }
            return NotFound();
        }

        [HttpPost] // TODO: Change behaviour to random creation
        public ActionResult AddItem(ItemWriteDto it)
        {
            var It = _map.Map<Item>(it);
            _repo.AddItem(It);
            return CreatedAtRoute(nameof(GetItemById), new {Id = It.Id}, It);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _repo.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            _repo.RemoveItem(item);
            return Ok();
        }
    }
}