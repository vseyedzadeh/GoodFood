using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RecipeManagmentSystem.Models;
using RecipeManagmentSystem.ViewModels;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;

namespace RecipeManagmentSystem.Controllers
{
    public class RecipesController : Controller
    {
        ApplicationDbContext _context;
        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Display List of available Recipes in each category
        public ActionResult AvailableRecipes(int catId)
        {            
            var category = _context.Category.FirstOrDefault(c => c.ID == catId);
            if (category == null)
                return HttpNotFound();

            var recipes = _context.Recipe.Include(u => u.User).Where(r => r.CategoryID == catId && r.Approve == true).ToList();

            var favoriteList = new List<Favorite>();
            var username = User.Identity != null ? User.Identity.Name : null;
            if (!string.IsNullOrEmpty(username))
            {
                var userObj = _context.Users.FirstOrDefault(u => u.UserName == username);
                if (userObj != null)
                {
                    favoriteList = _context.Favorite.Where(u => u.UserID == userObj.Id).ToList();
                }
            }
            var recipeViewModelList = new List<RecipeViewModel>();

            foreach (var recipe in recipes)
            {
                var vm = new RecipeViewModel();
                vm.Recipe = recipe;
                vm.IsFavorite = favoriteList.Any(f => f.RecipeID == recipe.ID);

                recipeViewModelList.Add(vm);
            }

            var viewModel = new CategoryRecipeViewModel()
            {
                Category = category,
                Recipes = recipeViewModelList,
                UserName = username
            };

            return View(viewModel);
        }

        // GET: Selected Recipe's Detail
        public ActionResult Detail(int RecipeId)
        {

            var selectedRecipe = _context.Recipe.Include(u => u.User).SingleOrDefault(r => r.ID == RecipeId);
            var ingredients = selectedRecipe.Ingredients.Split('\n').Where(i => !String.IsNullOrEmpty(i)).ToList();

            var shoppingList = new List<ShoppingList>();
            var ingredientsViewModel = new List<IngredientViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                var userObj = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

                shoppingList = _context.ShoppingList.Where(s => s.UserID == userObj.Id).ToList();
            }

            foreach (var ingredient in ingredients)
            {
                var vm = new IngredientViewModel();
                vm.Name = ingredient;
                vm.IsInShoppingList = shoppingList.Any(x => x.ItemName.ToLowerInvariant() == ingredient.ToLowerInvariant());

                ingredientsViewModel.Add(vm);
            }

            var viewModel = new RecipeDetailViewModel()
            {
                Recipe = selectedRecipe,
                Ingredients = ingredientsViewModel
            };

            return View(viewModel);
        }
        
        //POST: MakeFavorite(Action for button Favorite)
        [HttpPost]
        public ActionResult MakeFavorite(int recipeId, string userName)
        {
            var user = User.Identity;

            if (userName == null || user == null || user.Name != userName)
                return View("Login");

            var recipe = _context.Recipe.Find(recipeId);
            if (recipe == null)
                return View("Error");

            var userObj = _context.Users.FirstOrDefault(u => u.UserName == userName);
            Favorite favorite = null;
            if (userObj != null)
            {
                favorite = _context.Favorite.SingleOrDefault(f => f.RecipeID == recipeId && f.UserID == userObj.Id);
            }
            var isFavorite = false;
            if ( favorite!= null)
            {                
                _context.Favorite.Remove(favorite);
            }
            else
            {
                isFavorite = true;
                favorite = new Favorite();
                favorite.User = userObj;
                favorite.Recipe = recipe;
                _context.Favorite.Add(favorite);
            }
            _context.SaveChanges();

            return Json(new { success = true, favorite = isFavorite });
        }


        //GET: Add New Recipe
        [Authorize]
        public ActionResult Add()
        {
            var viewModel = new RecipeCategoryViewModel()
            {
                Recipe = new Recipe(),
                CategoryList = _context.Category.ToList()
            };
            return View(viewModel);
        }

        //get edit for admin
        [Authorize(Roles = "admin")]
        public ActionResult PendingEdit(int id)
        {
            var result = _context.Recipe.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            var viewModel = new RecipeCategoryViewModel()
            {
                Recipe = new Recipe(),
                CategoryList = _context.Category.ToList()
            };
            return View(viewModel);

        }

        // [HttpPost]
        //   [ValidateAntiForgeryToken]
        //POST Delete recipe
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _context.Recipe.Find(id);
                if (result == null)
                    return View("Error");//new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                _context.Recipe.Remove(result);
                _context.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("PendingDetails", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Pending");
        }

        //Post: Saving add edit recipe
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Recipe recipe)
        {
            //Server side validation - start
            if (!ModelState.IsValid)
            {
                var viewModel = new RecipeCategoryViewModel()
                {
                    Recipe = recipe,
                    CategoryList = _context.Category.ToList()
                };

                return View("Add", viewModel);
            }
            //**********Server side validation - end *********
            if (recipe.ID == 0)
            {
                recipe.Approve = false;
                recipe.UserID = User.Identity.GetUserId();
                _context.Recipe.Add(recipe);
            }
            else
            {
                var RecipeDb = _context.Recipe.First(c => c.ID == recipe.ID);

                RecipeDb.Title = recipe.Title;
                RecipeDb.CategoryID = recipe.CategoryID;
                RecipeDb.CookTime = recipe.CookTime;
                RecipeDb.Country = recipe.Country;
                RecipeDb.Description = recipe.Description;
                RecipeDb.Direction = recipe.Direction;
                RecipeDb.Ingredients = recipe.Ingredients;
                RecipeDb.NumOfServ = recipe.NumOfServ;
                RecipeDb.PrepTime = recipe.PrepTime;
                RecipeDb.UserID = User.Identity.GetUserId();
                //RecipeDb.Approve = false;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        //Get list of pending recipe to be approved
        //only admin can see, edit or delete
        [Authorize(Roles = "Admin")]
        public ActionResult Pending()
        {
            var result = _context.Recipe.Where(c => c.Approve == false).Include(c => c.Category).ToList();
            ViewBag.Success = TempData["approved"];
            return View(result);
        }
        //GET Detail of pending recipe
        //only admin can see, edit or delete
        [Authorize(Roles = "Admin")]
        public ActionResult PendingDetails(int id, bool? saveChangesError = false)
        {
            var details = _context.Recipe.Include(c => c.Category).First(c => c.ID == id);
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete Failed. Please try again or contact adminstrator";
            }
            return View(details);
        }
        //Approve Recipe
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult PendingApprove(int id)
        {
            var result = _context.Recipe.First(c => c.ID == id);
            if (result == null)
            {
                return HttpNotFound();
            }
            result.Approve = true;
             _context.SaveChanges();
            TempData["approved"] = "You have approved a recipe name:" + result.Title;
            return RedirectToAction("Pending");
        }
        
    }
}