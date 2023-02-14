namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transferorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transfer_Order",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        from_company_id = c.Int(nullable: false),
                        to_company_id = c.Int(nullable: false),
                        Product_Typeid = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        tr_count = c.Double(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        order_no = c.String(),
                        transfer_from_date = c.DateTime(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.from_company_id, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.to_company_id, cascadeDelete: false)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.from_company_id)
                .Index(t => t.to_company_id)
                .Index(t => t.Product_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfer_Order", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Transfer_Order", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Transfer_Order", "Featureid", "dbo.Features");
            DropIndex("dbo.Transfer_Order", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Transfer_Order", new[] { "Featureid" });
            DropIndex("dbo.Transfer_Order", new[] { "Product_Typeid" });
            DropTable("dbo.Transfer_Order");
        }
    }
}
