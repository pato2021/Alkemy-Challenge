namespace BudgetManagerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operations", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Operations", new[] { "CategoryId" });
            AlterColumn("dbo.Operations", "CategoryId", c => c.Int());
            CreateIndex("dbo.Operations", "CategoryId");
            AddForeignKey("dbo.Operations", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Operations", new[] { "CategoryId" });
            AlterColumn("dbo.Operations", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Operations", "CategoryId");
            AddForeignKey("dbo.Operations", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
