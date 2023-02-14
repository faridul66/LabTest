namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigbang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Machine_Product",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Machineid = c.Int(nullable: false),
                        Product_Typeid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Machines", t => t.Machineid, cascadeDelete: true)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .Index(t => t.Machineid)
                .Index(t => t.Product_Typeid);
            
            CreateTable(
                "dbo.Production_Indent",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Machineid = c.Int(nullable: false),
                        Product_Typeid = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Shiftid = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                        batch_count = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        prod_count = c.Double(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        indent_no = c.String(),
                        indent_date = c.DateTime(nullable: false),
                        shift_start = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: true)
                .ForeignKey("dbo.Machines", t => t.Machineid, cascadeDelete: false)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Shifts", t => t.Shiftid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.Machineid)
                .Index(t => t.Product_Typeid)
                .Index(t => t.Shiftid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shift_code = c.String(),
                        name = c.String(),
                        duration = c.Int(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: true)
                .Index(t => t.Unit_Measurementid);
            
            CreateTable(
                "dbo.Purchase_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        pur_count = c.Double(nullable: false),
                        Locationid = c.Int(nullable: false),
                        arrival_date = c.DateTime(nullable: false),
                        Purchase_Orderid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Purchase_Order", t => t.Purchase_Orderid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Locationid)
                .Index(t => t.Purchase_Orderid);
            
            CreateTable(
                "dbo.Purchase_Order",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Companyid = c.Int(nullable: false),
                        Vendorid = c.Int(nullable: false),
                        Product_Typeid = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        pur_count = c.Double(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        order_no = c.String(),
                        lc_number = c.String(),
                        lc_date = c.DateTime(nullable: false),
                        purchase_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.Companyid, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: false)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .ForeignKey("dbo.Vendors", t => t.Vendorid, cascadeDelete: false)
                .Index(t => t.Companyid)
                .Index(t => t.Vendorid)
                .Index(t => t.Product_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid)
                .Index(t => t.Locationid);
            
            CreateTable(
                "dbo.Sales_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        sale_count = c.Double(nullable: false),
                        Locationid = c.Int(nullable: false),
                        delivery_date = c.DateTime(nullable: false),
                        Sales_Orderid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Sales_Order", t => t.Sales_Orderid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Locationid)
                .Index(t => t.Sales_Orderid);
            
            CreateTable(
                "dbo.Sales_Order",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Companyid = c.Int(nullable: false),
                        Customerid = c.Int(nullable: false),
                        Product_Typeid = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        sale_count = c.Double(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        order_no = c.String(),
                        sell_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.Companyid, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customerid, cascadeDelete: false)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: false)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.Companyid)
                .Index(t => t.Customerid)
                .Index(t => t.Product_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid)
                .Index(t => t.Locationid);

            CreateTable(
                "dbo.Shift_End",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Production_Indentid = c.Int(nullable: false),
                    consumption_residual = c.Double(nullable: false),
                    product_wastage = c.Double(nullable: false),
                    residual_unit = c.Int(nullable: false),
                    wastage_unit = c.Int(nullable: false),
                    shift_end = c.DateTime(nullable: false),
                    status = c.String(),
                    chged_by = c.String(),
                    chgd_date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Production_Indent", t => t.Production_Indentid, cascadeDelete: true)
                .ForeignKey("dbo.Unit_Measurement", t => t.residual_unit, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.wastage_unit, cascadeDelete: false)
                .Index(t => t.Production_Indentid)
                .Index(t => t.residual_unit)
                .Index(t => t.wastage_unit);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shift_End", "Production_Indentid", "dbo.Production_Indent");
            DropForeignKey("dbo.Sales_Ledger", "Sales_Orderid", "dbo.Sales_Order");
            DropForeignKey("dbo.Sales_Order", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Sales_Order", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Sales_Order", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Sales_Order", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Sales_Order", "Customerid", "dbo.Customers");
            DropForeignKey("dbo.Sales_Order", "Companyid", "dbo.Companies");
            DropForeignKey("dbo.Sales_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Sales_Ledger", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Purchase_Ledger", "Purchase_Orderid", "dbo.Purchase_Order");
            DropForeignKey("dbo.Purchase_Order", "Vendorid", "dbo.Vendors");
            DropForeignKey("dbo.Purchase_Order", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Purchase_Order", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Purchase_Order", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Purchase_Order", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Purchase_Order", "Companyid", "dbo.Companies");
            DropForeignKey("dbo.Purchase_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Purchase_Ledger", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Production_Indent", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Production_Indent", "Shiftid", "dbo.Shifts");
            DropForeignKey("dbo.Shifts", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Production_Indent", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Production_Indent", "Machineid", "dbo.Machines");
            DropForeignKey("dbo.Production_Indent", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Machine_Product", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Machine_Product", "Machineid", "dbo.Machines");
            DropIndex("dbo.Shift_End", new[] { "Production_Indentid" });
            DropIndex("dbo.Sales_Order", new[] { "Locationid" });
            DropIndex("dbo.Sales_Order", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Sales_Order", new[] { "Featureid" });
            DropIndex("dbo.Sales_Order", new[] { "Product_Typeid" });
            DropIndex("dbo.Sales_Order", new[] { "Customerid" });
            DropIndex("dbo.Sales_Order", new[] { "Companyid" });
            DropIndex("dbo.Sales_Ledger", new[] { "Sales_Orderid" });
            DropIndex("dbo.Sales_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Sales_Ledger", new[] { "Productid" });
            DropIndex("dbo.Purchase_Order", new[] { "Locationid" });
            DropIndex("dbo.Purchase_Order", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Purchase_Order", new[] { "Featureid" });
            DropIndex("dbo.Purchase_Order", new[] { "Product_Typeid" });
            DropIndex("dbo.Purchase_Order", new[] { "Vendorid" });
            DropIndex("dbo.Purchase_Order", new[] { "Companyid" });
            DropIndex("dbo.Purchase_Ledger", new[] { "Purchase_Orderid" });
            DropIndex("dbo.Purchase_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Purchase_Ledger", new[] { "Productid" });
            DropIndex("dbo.Shifts", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Production_Indent", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Production_Indent", new[] { "Featureid" });
            DropIndex("dbo.Production_Indent", new[] { "Shiftid" });
            DropIndex("dbo.Production_Indent", new[] { "Product_Typeid" });
            DropIndex("dbo.Production_Indent", new[] { "Machineid" });
            DropIndex("dbo.Machine_Product", new[] { "Product_Typeid" });
            DropIndex("dbo.Machine_Product", new[] { "Machineid" });
            DropTable("dbo.Shift_End");
            DropTable("dbo.Sales_Order");
            DropTable("dbo.Sales_Ledger");
            DropTable("dbo.Purchase_Order");
            DropTable("dbo.Purchase_Ledger");
            DropTable("dbo.Shifts");
            DropTable("dbo.Production_Indent");
            DropTable("dbo.Machine_Product");
        }
    }
}
