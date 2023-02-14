namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropIndex("dbo.ProductType_FeatureType", new[] { "Unit_Measurementid" });
            AlterColumn("dbo.Feature_Type", "parent_type", c => c.Int());
            AlterColumn("dbo.ProductType_FeatureType", "Unit_Measurementid", c => c.Int());
            CreateIndex("dbo.ProductType_FeatureType", "Unit_Measurementid");
            AddForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropIndex("dbo.ProductType_FeatureType", new[] { "Unit_Measurementid" });
            AlterColumn("dbo.ProductType_FeatureType", "Unit_Measurementid", c => c.Int(nullable: false));
            AlterColumn("dbo.Feature_Type", "parent_type", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductType_FeatureType", "Unit_Measurementid");
            AddForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement", "id", cascadeDelete: true);
        }
    }
}
