namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Other_Consumption", "Product_Typeid", c => c.Int(nullable: false));
            AddColumn("dbo.Other_Consumption", "Other_Typeid", c => c.Int(nullable: false));
            AddColumn("dbo.Vendors", "chgd_date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Other_Consumption", "Product_Typeid");
            CreateIndex("dbo.Other_Consumption", "Other_Typeid");
            AddForeignKey("dbo.Other_Consumption", "Other_Typeid", "dbo.Other_Type", "id", cascadeDelete: true);
            AddForeignKey("dbo.Other_Consumption", "Product_Typeid", "dbo.Product_Type", "id", cascadeDelete: true);
            DropColumn("dbo.Other_Consumption", "type_code");
            DropColumn("dbo.Other_Consumption", "type_name");
            DropColumn("dbo.Other_Consumption", "product_type");
            DropColumn("dbo.Other_Consumption", "other_type");
            DropColumn("dbo.Vendors", "chged_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "chged_datetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Other_Consumption", "other_type", c => c.Int(nullable: false));
            AddColumn("dbo.Other_Consumption", "product_type", c => c.Int(nullable: false));
            AddColumn("dbo.Other_Consumption", "type_name", c => c.String());
            AddColumn("dbo.Other_Consumption", "type_code", c => c.String());
            DropForeignKey("dbo.Other_Consumption", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Other_Consumption", "Other_Typeid", "dbo.Other_Type");
            DropIndex("dbo.Other_Consumption", new[] { "Other_Typeid" });
            DropIndex("dbo.Other_Consumption", new[] { "Product_Typeid" });
            DropColumn("dbo.Vendors", "chgd_date");
            DropColumn("dbo.Other_Consumption", "Other_Typeid");
            DropColumn("dbo.Other_Consumption", "Product_Typeid");
        }
    }
}
