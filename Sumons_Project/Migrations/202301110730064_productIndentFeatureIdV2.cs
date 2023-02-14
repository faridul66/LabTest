namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productIndentFeatureIdV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Indent_Feature", "Unit_Measurementid", c => c.Int());
            CreateIndex("dbo.Product_Indent_Feature", "Unit_Measurementid");
            AddForeignKey("dbo.Product_Indent_Feature", "Unit_Measurementid", "dbo.Unit_Measurement", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Indent_Feature", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropIndex("dbo.Product_Indent_Feature", new[] { "Unit_Measurementid" });
            DropColumn("dbo.Product_Indent_Feature", "Unit_Measurementid");
        }
    }
}
