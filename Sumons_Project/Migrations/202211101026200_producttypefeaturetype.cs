namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttypefeaturetype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductType_FeatureType", "Featureid", "dbo.Features");
            DropIndex("dbo.ProductType_FeatureType", new[] { "Featureid" });
            AddColumn("dbo.ProductType_FeatureType", "Feature_Typeid", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductType_FeatureType", "Feature_Typeid");
            AddForeignKey("dbo.ProductType_FeatureType", "Feature_Typeid", "dbo.Feature_Type", "id", cascadeDelete: true);
            DropColumn("dbo.ProductType_FeatureType", "Featureid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductType_FeatureType", "Featureid", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductType_FeatureType", "Feature_Typeid", "dbo.Feature_Type");
            DropIndex("dbo.ProductType_FeatureType", new[] { "Feature_Typeid" });
            DropColumn("dbo.ProductType_FeatureType", "Feature_Typeid");
            CreateIndex("dbo.ProductType_FeatureType", "Featureid");
            AddForeignKey("dbo.ProductType_FeatureType", "Featureid", "dbo.Features", "id", cascadeDelete: false);
        }
    }
}
