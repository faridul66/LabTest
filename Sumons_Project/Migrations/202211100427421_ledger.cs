namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ledger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consumption_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        prod_count = c.Double(nullable: false),
                        Production_Indentid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        consumption_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Production_Indent", t => t.Production_Indentid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Production_Indentid)
                .Index(t => t.Locationid);
            
            CreateTable(
                "dbo.General_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        Transaction_Typeid = c.Int(nullable: false),
                        trans_ref_id = c.Int(nullable: false),
                        trans_date = c.DateTime(nullable: false),
                        is_current = c.Boolean(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Transaction_Type", t => t.Transaction_Typeid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Transaction_Typeid);
            
            CreateTable(
                "dbo.Other_Consumption",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_code = c.String(),
                        type_name = c.String(),
                        Companyid = c.Int(nullable: false),
                        product_type = c.Int(nullable: false),
                        other_type = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                        cons_feature = c.Int(nullable: false),
                        cons_count = c.Double(nullable: false),
                        cons_unit = c.Int(nullable: false),
                        description = c.String(),
                        other_start_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.Companyid, cascadeDelete: false)
                .Index(t => t.Companyid);
            
            CreateTable(
                "dbo.Other_Consumption_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        cons_count = c.Double(nullable: false),
                        other_consumption_id = c.Int(nullable: false),
                        from_warehouse_id = c.Int(nullable: false),
                        consumption_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .Index(t => t.Productid);
            
            CreateTable(
                "dbo.Other_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_code = c.String(),
                        type_name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Production_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        prod_count = c.Double(nullable: false),
                        Production_Indentid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        production_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Production_Indent", t => t.Production_Indentid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Production_Indentid)
                .Index(t => t.Locationid);
            
            CreateTable(
                "dbo.ProductType_FeatureType",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product_Typeid = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.Product_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
            
            CreateTable(
                "dbo.Transfer_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        tr_count = c.Double(nullable: false),
                        transfer_order_id = c.Int(nullable: false),
                        to_warehouse_id = c.Int(nullable: false),
                        arrival_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .Index(t => t.Productid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfer_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.ProductType_FeatureType", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.ProductType_FeatureType", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.ProductType_FeatureType", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Production_Ledger", "Production_Indentid", "dbo.Production_Indent");
            DropForeignKey("dbo.Production_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Production_Ledger", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Other_Consumption_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Other_Consumption", "Companyid", "dbo.Companies");
            DropForeignKey("dbo.General_Ledger", "Transaction_Typeid", "dbo.Transaction_Type");
            DropForeignKey("dbo.General_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Consumption_Ledger", "Production_Indentid", "dbo.Production_Indent");
            DropForeignKey("dbo.Consumption_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Consumption_Ledger", "Locationid", "dbo.Locations");
            DropIndex("dbo.Transfer_Ledger", new[] { "Productid" });
            DropIndex("dbo.ProductType_FeatureType", new[] { "Unit_Measurementid" });
            DropIndex("dbo.ProductType_FeatureType", new[] { "Featureid" });
            DropIndex("dbo.ProductType_FeatureType", new[] { "Product_Typeid" });
            DropIndex("dbo.Production_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Production_Ledger", new[] { "Production_Indentid" });
            DropIndex("dbo.Production_Ledger", new[] { "Productid" });
            DropIndex("dbo.Other_Consumption_Ledger", new[] { "Productid" });
            DropIndex("dbo.Other_Consumption", new[] { "Companyid" });
            DropIndex("dbo.General_Ledger", new[] { "Transaction_Typeid" });
            DropIndex("dbo.General_Ledger", new[] { "Productid" });
            DropIndex("dbo.Consumption_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Consumption_Ledger", new[] { "Production_Indentid" });
            DropIndex("dbo.Consumption_Ledger", new[] { "Productid" });
            DropTable("dbo.Transfer_Ledger");
            DropTable("dbo.ProductType_FeatureType");
            DropTable("dbo.Production_Ledger");
            DropTable("dbo.Other_Type");
            DropTable("dbo.Other_Consumption_Ledger");
            DropTable("dbo.Other_Consumption");
            DropTable("dbo.General_Ledger");
            DropTable("dbo.Consumption_Ledger");
        }
    }
}
