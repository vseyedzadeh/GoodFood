using RecipeManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public bool IsFavorite { get; set; }
    }
}