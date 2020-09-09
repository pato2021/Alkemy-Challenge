namespace BudgetManagerApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ultimate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operations", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "Type", c => c.String(maxLength: 50));
        }
    }
}
