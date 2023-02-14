namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedResiduals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Residuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LedgerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                        ResidualValue = c.Double(nullable: false),
                        PreviousValue = c.Double(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Residuals");
        }
    }
}
