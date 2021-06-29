using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChefByStep.ASP.ViewModels
{
    public class RecipeCreateViewModel
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        [DisplayName("Category: ")]
        [Required(ErrorMessage = "A category is required")]
        public Category CategoryId { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [MinLength(5, ErrorMessage = "Description must be longer than 5 characters")]
        public string Description { get; set; }

        [DisplayName("Image Link: ")]
        [Required(ErrorMessage = "An image link is required")]
        [MinLength(5, ErrorMessage = "Url must be longer than 5 characters")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "An title is required")]
        [MinLength(5, ErrorMessage = "Title must be longer than 5 characters")]
        public string Title { get; set; }

        [DisplayName("Preparation Time (in minutes): ")]
        [Required(ErrorMessage = "Preparation time is required")]
        [Range(0, 1000, ErrorMessage = "Preparation time must be between 0 and 1000")]
        public int? PrepTimeInMin { get; set; }

        [DisplayName("Cooking Time (in minutes): ")]
        [Required(ErrorMessage = "Cooking time is required")]
        [Range(0, 1000, ErrorMessage = "Cooking time must be between 0 and 1000")]
        public int? CookTimeInMin { get; set; }

        public List<Step> Steps { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
        public ApiUser CreatedBy { get; set; }
    }
}