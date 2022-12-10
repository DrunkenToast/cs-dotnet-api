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
    // [Route("keys")]
    public class KeyController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _map;
        private readonly Random _rnd = new Random();

        public KeyController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        [HttpGet]
        [Route("keys")]
        public ActionResult GetKeys()
        {
            return Ok(_map.Map<KeysReadDto>(_repo.GetKeys()));
        }

        // [HttpGet("{id}", Name="GetItemById")]
        // public ActionResult GetItemById(int id)
        // {

        // }

        [HttpPost]
        [Route("purchase")]
        public ActionResult PurchaseKeys()
        {
            var keys = _repo.GetKeys();
            keys.Amount += 1;
            _repo.UpdateKeys(keys);
            return Ok();
        }
    }
}