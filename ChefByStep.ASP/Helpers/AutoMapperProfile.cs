namespace ChefByStep.ASP.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using ChefByStep.ASP.Models;
    using ChefByStep.ASP.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, RecipeDetailViewModel>().ReverseMap();
            CreateMap<RecipeIngredient, Ingredient>().ReverseMap();
            CreateMap<RecipeRating, RecipeRatingViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeCreateViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeEditViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeDeleteViewModel>().ReverseMap();
        }
    }
}