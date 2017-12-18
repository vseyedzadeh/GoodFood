using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeManagmentSystem.Models;

namespace RecipeManagmentSystem.ViewModels
{
    public class CategoryRecipeViewModel
    {
        public Category Category { get; set; }
        public List<RecipeViewModel> Recipes { get; set; }
        public String UserName { get; set; }        
    }
}