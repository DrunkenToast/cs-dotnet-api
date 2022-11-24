using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cs_dotnet_api.dto;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemWriteDto, Item>();
        }
    }
}