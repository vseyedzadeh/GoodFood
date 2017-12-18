namespace RecipeManagmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'fc11b07b-ecee-4ba4-9e56-df61faa5bd1f', N'admin@recipe.com', 0, N'AN24v9xmcOcpyjckXto6CZrsb3ZeGJtEKh7tY9bG6zuk/HoxS/WanLtvZym3C3M9RA==', N'3012aca5-8e47-40e3-94e2-c876f60a405a', NULL, 0, 0, NULL, 1, 0, N'admin@recipe.com')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9f2870a1-8af0-43d5-8ac0-922b02792241', N'Admin')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc11b07b-ecee-4ba4-9e56-df61faa5bd1f', N'9f2870a1-8af0-43d5-8ac0-922b02792241')");

        }

        public override void Down()
        {
        }
    }
}
