namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Return_Ledger",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        Return_Orderid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        actual_return_date = c.DateTime(nullable: false),
                        return_value = c.Double(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Return_Order", t => t.Return_Orderid, cascadeDelete: false)
                .Index(t => t.Productid)
                .Index(t => t.Return_Orderid)
                .Index(t => t.Locationid);
            
            CreateTable(
                "dbo.Return_Order",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Companyid = c.Int(nullable: false),
                        Transaction_Typeid = c.Int(nullable: false),
                        return_date = c.DateTime(nullable: false),
                        qty = c.Double(nullable: false),
                        Featureid = c.Int(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        return_order_code = c.String(),
                        description = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.Companyid, cascadeDelete: false)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Transaction_Type", t => t.Transaction_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.Companyid)
                .Index(t => t.Transaction_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Return_Ledger", "Return_Orderid", "dbo.Return_Order");
            DropForeignKey("dbo.Return_Order", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Return_Order", "Transaction_Typeid", "dbo.Transaction_Type");
            DropForeignKey("dbo.Return_Order", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Return_Order", "Companyid", "dbo.Companies");
            DropForeignKey("dbo.Return_Ledger", "Productid", "dbo.Products");
            DropForeignKey("dbo.Return_Ledger", "Locationid", "dbo.Locations");
            DropIndex("dbo.Return_Order", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Return_Order", new[] { "Featureid" });
            DropIndex("dbo.Return_Order", new[] { "Transaction_Typeid" });
            DropIndex("dbo.Return_Order", new[] { "Companyid" });
            DropIndex("dbo.Return_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Return_Ledger", new[] { "Return_Orderid" });
            DropIndex("dbo.Return_Ledger", new[] { "Productid" });
            DropTable("dbo.Return_Order");
            DropTable("dbo.Return_Ledger");
        }
    }
}
