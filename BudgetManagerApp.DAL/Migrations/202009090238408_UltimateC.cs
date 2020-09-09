namespace BudgetManagerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UltimateC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Type", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Type");
        }
    }
}
