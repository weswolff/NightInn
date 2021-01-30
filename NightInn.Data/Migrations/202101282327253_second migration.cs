namespace NightInn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drinks", "Ingredients", c => c.String());
            AlterColumn("dbo.Foods", "Ingredients", c => c.String());
            AlterColumn("dbo.Foods", "Instructions", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Instructions", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "Ingredients", c => c.String(nullable: false));
            AlterColumn("dbo.Drinks", "Ingredients", c => c.String(nullable: false));
        }
    }
}
