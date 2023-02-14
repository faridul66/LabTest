namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featureproductN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Feature",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        Value = c.Double(nullable: true),
                        Unit_Measurementid = c.Int(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid)
                .Index(t => t.Productid)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Feature", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Product_Feature", "Productid", "dbo.Products");
            DropForeignKey("dbo.Product_Feature", "Featureid", "dbo.Features");
            DropIndex("dbo.Product_Feature", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Product_Feature", new[] { "Featureid" });
            DropIndex("dbo.Product_Feature", new[] { "Productid" });
            DropTable("dbo.Product_Feature");
        }
    }
}
