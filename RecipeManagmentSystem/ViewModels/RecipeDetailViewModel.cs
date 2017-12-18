using RecipeManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RecipeManagmentSystem.ViewModels
{
    public class RecipeDetailViewModel
    {
        public Recipe Recipe { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }
}