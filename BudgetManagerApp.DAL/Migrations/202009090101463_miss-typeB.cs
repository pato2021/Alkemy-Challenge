namespace BudgetManagerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class misstypeB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "Type", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "Type");
        }
    }
}
