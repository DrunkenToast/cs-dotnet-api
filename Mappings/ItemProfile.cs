using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cs_dotnet_api.dto;
using cs_dotnet_api.Models;

namespace cs_dotnet_api.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Item, ItemReadDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.ItemName.Name)
                );
            CreateMap<ItemWriteDto, Item>();
            CreateMap<Keys, KeysReadDto>()
            .ForMember(dto => dto.Amount, opt => opt.MapFrom(keys => keys.Amount));
        }
    }
}