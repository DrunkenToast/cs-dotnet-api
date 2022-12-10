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
        private readonly Random _rnd = new Random();

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

        [HttpPost]
        public ActionResult UnboxRandomItem()
        {
            // First detuct key
            var keys = _repo.GetKeys();

            if (keys.Amount < 1) {
                return StatusCode(StatusCodes.Status403Forbidden, "Reason: You do not own a key to unbox a crate.");
            }

            keys.Amount--;
            _repo.UpdateKeys(keys);

            // Create item
            int num = _rnd.Next(100);

            QualityType q = num switch {
                < 1 => QualityType.Community,
                < 2 => QualityType.Unusual,
                < 7 => QualityType.Genuine,
                < 25 => QualityType.Strange,
                < 40 => QualityType.Vintage,
                _ => QualityType.Unique,
            };

            var it = new Item(){
                ItemName = _repo.GetRandomItemName(),
                Quality = q,
            };

            _repo.AddItem(it);
            return CreatedAtRoute(
                nameof(GetItemById),
                new {Id = it.Id},
                _map.Map<ItemReadDto>(it)
            );
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