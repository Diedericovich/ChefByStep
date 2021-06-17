using AutoMapper;
using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dst => dst.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy.Name))
                .ReverseMap();
        }
    }
}