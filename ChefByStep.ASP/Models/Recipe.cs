using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ChefByStep.ASP.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [JsonProperty]
        public int CreatedById { get; set; }

        [JsonProperty]
        public Category CategoryId { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        public List<RecipeRating> Ratings { get; set; }

        [JsonProperty]
        public string ImageUrl { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        public string CreatedByUser { get; set; }

        [JsonProperty]
        public int PrepTimeInMin { get; set; }

        [JsonProperty]
        public int CookTimeInMin { get; set; }

        [JsonProperty]
        public List<RecipeIngredient> Ingredients { get; set; }

        [JsonProperty]
        public List<Step> Steps { get; set; }

        [NotMapped]
        public ApiUser CreatedBy { get; set; }

        [NotMapped]
        public List<ApiUser> FavouritedBy { get; set; }

        [NotMapped]
        public List<ApiUser> CompletedBy { get; set; }
    }
}