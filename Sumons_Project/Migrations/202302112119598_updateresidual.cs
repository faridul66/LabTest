namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateresidual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residuals", "ProductionIndentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residuals", "ProductionIndentId");
        }
    }
}
