namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_feature : DbMigration
    {
        public override void Up()
        {
           // DropForeignKey("dbo.Product_Feature", "Feature_Typeid", "dbo.Feature_Type");
            DropIndex("dbo.Product_Feature", new[] { "Feature_Typeid" });
            AddColumn("dbo.Product_Feature", "Featureid", c => c.Int(nullable: false));
            CreateIndex("dbo.Product_Feature", "Featureid");
            AddForeignKey("dbo.Product_Feature", "Featureid", "dbo.Features", "id", cascadeDelete: true);
            DropColumn("dbo.Product_Feature", "Feature_Typeid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product_Feature", "Feature_Typeid", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product_Feature", "Featureid", "dbo.Features");
            DropIndex("dbo.Product_Feature", new[] { "Featureid" });
            DropColumn("dbo.Product_Feature", "Featureid");
            CreateIndex("dbo.Product_Feature", "Feature_Typeid");
            AddForeignKey("dbo.Product_Feature", "Feature_Typeid", "dbo.Feature_Type", "id", cascadeDelete: true);
        }
    }
}
