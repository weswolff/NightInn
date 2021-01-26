namespace NightInn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Themes", "Food_FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "Theme_ThemeId", "dbo.Themes");
            DropIndex("dbo.Themes", new[] { "Food_FoodId" });
            DropIndex("dbo.Foods", new[] { "Theme_ThemeId" });
            DropColumn("dbo.Themes", "Food_FoodId");
            DropColumn("dbo.Foods", "Theme_ThemeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "Theme_ThemeId", c => c.Int());
            AddColumn("dbo.Themes", "Food_FoodId", c => c.Int());
            CreateIndex("dbo.Foods", "Theme_ThemeId");
            CreateIndex("dbo.Themes", "Food_FoodId");
            AddForeignKey("dbo.Foods", "Theme_ThemeId", "dbo.Themes", "ThemeId");
            AddForeignKey("dbo.Themes", "Food_FoodId", "dbo.Foods", "FoodId");
        }
    }
}
