using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeManagmentSystem.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        public string Image { get; set; }

    }
}