using AutoMapper;
using ChefByStep.ASP.Models;
using ChefByStep.ASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, RecipeDetailViewModel>().ReverseMap();
            CreateMap<RecipeIngredient, Ingredient>().ReverseMap();

        }
        
    }
}
