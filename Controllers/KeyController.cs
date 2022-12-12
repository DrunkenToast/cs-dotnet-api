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
    public class KeyController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _map;

        public KeyController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        [HttpGet]
        [Route("keys", Name="GetKeys")]
        public ActionResult GetKeys()
        {
            return Ok(_map.Map<KeysReadDto>(_repo.GetKeys()));
        }

        [HttpPost]
        [Route("purchase")]
        public ActionResult PurchaseKeys(PurchaseWriteDto purchaseWriteDto)
        {
            if (purchaseWriteDto.Amount < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Has to be a postive amount of keys");
            }

            var keys = _repo.GetKeys();

            keys.Amount += purchaseWriteDto.Amount;
            _repo.UpdateKeys(keys);

            // We do not create a resource, instead we update one and let the user now its Ok
            return Ok(
                _map.Map<KeysReadDto>(keys)
            );
        }
    }
}