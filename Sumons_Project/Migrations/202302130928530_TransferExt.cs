namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransferExt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransferOrderExts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromSite = c.Int(nullable: false),
                        FromWarehouse = c.Int(nullable: false),
                        ToSite = c.Int(nullable: false),
                        ToWarehouse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransferProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProdyctTypeId = c.Int(nullable: false),
                        FearureId = c.Int(nullable: false),
                        UnitId = c.Int(),
                        TxtValue = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransferProductFeatures");
            DropTable("dbo.TransferOrderExts");
        }
    }
}
