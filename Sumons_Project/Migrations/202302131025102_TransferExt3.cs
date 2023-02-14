namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TransferExt3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransferProductFeatures", "ProductTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.TransferProductFeatures", "FeatureTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.TransferProductFeatures", "ProdyctTypeId");
        }

        public override void Down()
        {
            AddColumn("dbo.TransferProductFeatures", "ProdyctTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.TransferProductFeatures", "FeatureTypeId");
            DropColumn("dbo.TransferProductFeatures", "ProductTypeId");
        }
    }
}
