namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderProductFeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.String(),
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
            DropTable("dbo.OrderProductFeatures");
        }
    }
}
