using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeManagmentSystem.Models;

namespace RecipeManagmentSystem.ViewModels
{
    public class RecipeCategoryViewModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public string Title => Recipe.ID == 0 ? "Add Recipe" : "Edit Recipe";

        public RecipeCategoryViewModel()
        {
            Recipe = new Recipe();
            Recipe.ID = 0;
        }
    }
}