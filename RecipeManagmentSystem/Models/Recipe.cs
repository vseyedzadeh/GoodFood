using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Required][MaxLength(120)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Direction { get; set; }

        [Required]
        [Range(1, 360, ErrorMessage = "Please enter a number between 1 and 360")]
        public int PrepTime { get; set; }

        [Required]
        [Range(1,360,ErrorMessage ="Please enter a number between 1 and 360")]
        public int CookTime { get; set; }

        [Required]
        public byte NumOfServ  { get; set; }

        public string Country { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public Category Category { get; set; }
        public int CategoryID { get; set; }

        public string Image { get; set; }

        public bool Approve { get; set; }
    }
}