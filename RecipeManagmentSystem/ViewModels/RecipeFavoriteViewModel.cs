using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeManagmentSystem.Models;

namespace RecipeManagmentSystem.ViewModels
{
    public class RecipeFavoriteViewModel
    {
        public List<FavoriteViewModel> Favorite { get; set; }
        public List<Recipe> Recipes { get; set; }
        public String UserName { get; set; }

     }
}