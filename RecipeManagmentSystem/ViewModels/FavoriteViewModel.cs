using RecipeManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.ViewModels
{
    public class FavoriteViewModel
    {
        public Favorite Favorite { get; set; }
        public string SubmitterUsername { get; set; }
    }
}