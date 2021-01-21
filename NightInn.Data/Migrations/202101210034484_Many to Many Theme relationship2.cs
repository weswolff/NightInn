namespace NightInn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManytoManyThemerelationship2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "ThemeId", "dbo.Themes");
            AddColumn("dbo.Themes", "Food_FoodId", c => c.Int());
            AddColumn("dbo.Foods", "Theme_ThemeId", c => c.Int());
            CreateIndex("dbo.Themes", "Food_FoodId");
            CreateIndex("dbo.Foods", "Theme_ThemeId");
            AddForeignKey("dbo.Themes", "Food_FoodId", "dbo.Foods", "FoodId");
            AddForeignKey("dbo.Foods", "Theme_ThemeId", "dbo.Themes", "ThemeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Theme_ThemeId", "dbo.Themes");
            DropForeignKey("dbo.Themes", "Food_FoodId", "dbo.Foods");
            DropIndex("dbo.Foods", new[] { "Theme_ThemeId" });
            DropIndex("dbo.Themes", new[] { "Food_FoodId" });
            DropColumn("dbo.Foods", "Theme_ThemeId");
            DropColumn("dbo.Themes", "Food_FoodId");
            AddForeignKey("dbo.Foods", "ThemeId", "dbo.Themes", "ThemeId", cascadeDelete: true);
        }
    }
}
