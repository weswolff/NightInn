namespace NightInn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(nullable: false),
                        DrinkAbv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ingredients = c.String(nullable: false),
                        Instructions = c.String(),
                        DrinkServingSize = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkId);
            
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        ThemeId = c.Int(nullable: false, identity: true),
                        ThemeName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ThemeId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false),
                        Ingredients = c.String(nullable: false),
                        Instructions = c.String(nullable: false),
                        FoodServingSize = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ThemeDrinks",
                c => new
                    {
                        Theme_ThemeId = c.Int(nullable: false),
                        Drink_DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theme_ThemeId, t.Drink_DrinkId })
                .ForeignKey("dbo.Themes", t => t.Theme_ThemeId, cascadeDelete: true)
                .ForeignKey("dbo.Drinks", t => t.Drink_DrinkId, cascadeDelete: true)
                .Index(t => t.Theme_ThemeId)
                .Index(t => t.Drink_DrinkId);
            
            CreateTable(
                "dbo.FoodThemes",
                c => new
                    {
                        Food_FoodId = c.Int(nullable: false),
                        Theme_ThemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_FoodId, t.Theme_ThemeId })
                .ForeignKey("dbo.Foods", t => t.Food_FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Themes", t => t.Theme_ThemeId, cascadeDelete: true)
                .Index(t => t.Food_FoodId)
                .Index(t => t.Theme_ThemeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FoodThemes", "Theme_ThemeId", "dbo.Themes");
            DropForeignKey("dbo.FoodThemes", "Food_FoodId", "dbo.Foods");
            DropForeignKey("dbo.ThemeDrinks", "Drink_DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.ThemeDrinks", "Theme_ThemeId", "dbo.Themes");
            DropIndex("dbo.FoodThemes", new[] { "Theme_ThemeId" });
            DropIndex("dbo.FoodThemes", new[] { "Food_FoodId" });
            DropIndex("dbo.ThemeDrinks", new[] { "Drink_DrinkId" });
            DropIndex("dbo.ThemeDrinks", new[] { "Theme_ThemeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.FoodThemes");
            DropTable("dbo.ThemeDrinks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Foods");
            DropTable("dbo.Themes");
            DropTable("dbo.Drinks");
        }
    }
}
