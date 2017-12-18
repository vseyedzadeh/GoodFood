namespace RecipeManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Categories (Title, Image) values ('Dessert', 'Dessert.jpg')");
            Sql("insert into Categories (Title, Image) values ('Dinner', 'dinner.jpg')");
            Sql("insert into Categories (Title, Image) values ('Breakfast And Brunch', 'breakfast-Brunch.jpg')");
            Sql("insert into Categories (Title, Image) values ('Snack', 'snack.jpg')");
            Sql("insert into Categories (Title, Image) values ('Main dish', 'Gravy.jpg')");
            Sql("insert into Categories (Title, Image) values ('Drink', 'drink.jpg')");
        }
        
        public override void Down()
        {
        }
    }
}
