namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesProductFeaturesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                        FeatureTypeId = c.Int(nullable: false),
                        FearureId = c.Int(nullable: false),
                        UnitId = c.Int(),
                        TxtValue = c.Double(),
                        CompanyId = c.Int(nullable: false),
                        LotNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesProductFeatures");
        }
    }
}
