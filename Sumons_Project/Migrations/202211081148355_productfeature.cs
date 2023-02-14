namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productfeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Feature",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        Feature_Typeid = c.Int(nullable: false),
                        Double = c.String(),
                        Unit_Measurementid = c.Int(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Feature_Type", t => t.Feature_Typeid, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: true)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid)
                .Index(t => t.Productid)
                .Index(t => t.Feature_Typeid)
                .Index(t => t.Unit_Measurementid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Feature", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Product_Feature", "Productid", "dbo.Products");
            DropForeignKey("dbo.Product_Feature", "Feature_Typeid", "dbo.Feature_Type");
            DropIndex("dbo.Product_Feature", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Product_Feature", new[] { "Feature_Typeid" });
            DropIndex("dbo.Product_Feature", new[] { "Productid" });
            DropTable("dbo.Product_Feature");
        }
    }
}
