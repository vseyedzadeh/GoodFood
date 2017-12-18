using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.Models
{
    public class Favorite
    {
        public int ID { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public Recipe Recipe { get; set; }
        public int RecipeID { get; set; }
    }
}