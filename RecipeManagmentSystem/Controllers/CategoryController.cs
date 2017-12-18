using RecipeManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeManagmentSystem.ViewModels;
using System.Data.Entity;

namespace RecipeManagmentSystem.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Display List of Category
       
        public ActionResult Index()
        {
            var categoryList = _context.Category.ToList();

            return View(categoryList);
        }

        
    }
}