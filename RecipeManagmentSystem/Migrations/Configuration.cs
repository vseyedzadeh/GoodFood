namespace RecipeManagmentSystem.Migrations
{
    using RecipeManagmentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeManagmentSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipeManagmentSystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var recipe = new Recipe() {
                Title = "Fresh Tomato Shrimp Pasta",
           PrepTime = 15,
            CookTime = 15,
            Description = "Fresh tomatoes and spinach, fresh herbs, and fresh mozzarella combine with shrimp and fettuccine for an easy summer dinner.",
            Ingredients = "8 ounces dry fettuccine pasta \n" +
            "3 cloves garlic \n" +
            "1/2 sweet onion, cut into wedges \n" +
            "1 pound cooked shrimp - peeled and deveined \n" +
            "4 medium tomatoes, chopped \n" +
            "1 cup spinach leaves",
            Direction = "<p>Bring a large pot of lightly salted water to a boil. Add the pasta, and cook for 8 minutes, or until tender. Drain.</P>" +
            "<p>In the container of a food processor, combine the garlic, onion and oregano. Pulse until finely chopped. Heat the olive oil in a large skillet over medium heat. Add the onion mixture; cook and stir until fragrant and almost golden. Mix in the tomatoes, basil, salt and pepper. Simmer for about 5 minutes while the pasta is cooking, stirring occasionally.</p>"+
"<p>Mix in spinach until it wilts, then just before the pasta is done, stir in the shrimp. Cook until heated through. Toss with pasta in a large serving bowl, and mix in mozzarella cheese.</p>",
            Image = "recipe1.jpg",
            CategoryID = context.Category.First(c => c.Title == "Dinner").ID,
            NumOfServ = 4,
            UserID = context.Users.First(u => u.Email == "admin@recipe.com").Id,
            Country = "Italy",
            Approve = true

            };      

            context.Set<Recipe>().AddOrUpdate(recipe);

            var recipe2 = new Recipe()
            {
                Title = "Gingerbread Cake with Lemon Glaze",
                PrepTime = 15,
                CookTime = 15,
                Description = "If you're looking for a new addition to your holiday dessert table, I hope you give this a try. Enjoy!",
                Ingredients = "1 2/3 cups all-purpose flour \n" +
            "2 teaspoons ground ginger \n" +
            "1 1/4 teaspoons baking soda \n" +
            "1 teaspoon ground cinnamon \n" +
            "1/4 teaspoon Chinese five-spice powder \n" +
            "1/2 cup dark molasses",
                Direction = "<p>Preheat oven to 350 degrees F (175 degrees C).Grease and lightly flour a 9-inch square baking pan.Whisk flour, ginger, baking soda, cinnamon, salt, and Chinese five-spice powder in a bowl.</P>" +
            "<p>Stir sugar, molasses, oil, and egg into flour mixture until just combined.Pour in boiling water and whisk until the batter is smooth and shiny, about 1 minute.Pour batter into prepared baking pan. Tap pan gently on the counter to remove any air bubbles.</p>" +
"<p>Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 35 minutes.Mix powdered sugar, lemon juice, and lemon zest in a bowl until sugar dissolves.Pour lemon juice mixture over cake while cake is still hot. Spread the mixture around with a spatula to ensure even distribution. Let cake cool completely before serving.</p>",
                Image = "recipe2.jpg",
                CategoryID = context.Category.First(c => c.Title == "Dessert").ID,
                NumOfServ = 4,
                UserID = context.Users.First(u => u.Email == "admin@recipe.com").Id,
                Country = "Italy",
                Approve = true

            };

            context.Set<Recipe>().AddOrUpdate(recipe2);
        }
    }
}
