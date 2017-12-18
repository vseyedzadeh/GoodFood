namespace RecipeManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeAddApproveTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Approve", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Approve");
        }
    }
}
