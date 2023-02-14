namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductTypeFeatureType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropIndex("dbo.ProductType_FeatureType", new[] { "Unit_Measurementid" });
            DropColumn("dbo.ProductType_FeatureType", "Unit_Measurementid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductType_FeatureType", "Unit_Measurementid", c => c.Int());
            CreateIndex("dbo.ProductType_FeatureType", "Unit_Measurementid");
            AddForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement", "id");
        }
    }
}
