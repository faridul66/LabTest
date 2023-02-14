namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Indent_Feature2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product_Indent_Feature", "Featureid", "dbo.Features");
            DropIndex("dbo.Product_Indent_Feature", new[] { "Featureid" });
            AddColumn("dbo.Product_Indent_Feature", "Feature_Typeid", c => c.Int());
            AlterColumn("dbo.Product_Indent_Feature", "Featureid", c => c.Int());
            CreateIndex("dbo.Product_Indent_Feature", "Featureid");
            CreateIndex("dbo.Product_Indent_Feature", "Feature_Typeid");
            AddForeignKey("dbo.Product_Indent_Feature", "Feature_Typeid", "dbo.Feature_Type", "id");
            AddForeignKey("dbo.Product_Indent_Feature", "Featureid", "dbo.Features", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Indent_Feature", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Product_Indent_Feature", "Feature_Typeid", "dbo.Feature_Type");
            DropIndex("dbo.Product_Indent_Feature", new[] { "Feature_Typeid" });
            DropIndex("dbo.Product_Indent_Feature", new[] { "Featureid" });
            AlterColumn("dbo.Product_Indent_Feature", "Featureid", c => c.Int(nullable: false));
            DropColumn("dbo.Product_Indent_Feature", "Feature_Typeid");
            CreateIndex("dbo.Product_Indent_Feature", "Featureid");
            AddForeignKey("dbo.Product_Indent_Feature", "Featureid", "dbo.Features", "id", cascadeDelete: true);
        }
    }
}
