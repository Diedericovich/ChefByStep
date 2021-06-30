using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Entities.DTOs
{
    public class FavouriteDto
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}