using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.Models
{
    public class ShoppingList
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }
        
    }
}