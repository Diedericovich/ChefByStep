using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Recipe Recipe { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}