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
                .ForMember(dst => dst.Ingredients, opt => opt.MapFrom(src => src.Ingredients))
                .ForMember(dst => dst.Steps, opt => opt.MapFrom(src => src.Steps))
                .ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientDto>()
                .ForMember(dst => dst.Ingredient, opt => opt.MapFrom(src => src.Ingredient))
                .ReverseMap();
            CreateMap<Ingredient, IngredientDto>()
                .ReverseMap();
            CreateMap<Step, StepDto>()
                .ReverseMap();
        }
    }
}