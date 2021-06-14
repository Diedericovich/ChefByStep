using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class Recipe: BaseModel
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public List<RecipeRating> Raitings { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }

        public List<Ingrediant> Ingrediants { get; set; }

        public List<Step> Steps { get; set; }

    }
}
