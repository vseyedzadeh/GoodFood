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
        public RecipeCategoryViewModel()
        {
            Recipe recipe = new Recipe()
            {
                ID = 0
            };
        }
    }
}