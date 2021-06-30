using ChefByStep.ASP.Models;
using ChefByStep.ASP.Services;
using ChefByStep.ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.ViewComponents
{
    public class AddToFavouritesComponent : ViewComponent
    {
        private IUserService _service;

        public AddToFavouritesComponent(IUserService service)
        {
            _service = service;
        }

        public async Task AddToFavourites(FavouriteDto favourite)
        {
            await _service.AddFavouriteRecipe(favourite);
        }
    }
}