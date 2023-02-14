namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featureproductD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product_Feature", "Featureid", "dbo.Features");
            DropForeignKey("dbo.Product_Feature", "Productid", "dbo.Products");
            DropForeignKey("dbo.Product_Feature", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropIndex("dbo.Product_Feature", new[] { "Productid" });
            DropIndex("dbo.Product_Feature", new[] { "Featureid" });
            DropIndex("dbo.Product_Feature", new[] { "Unit_Measurementid" });
            DropTable("dbo.Product_Feature");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Product_Feature",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Productid = c.Int(nullable: false),
                        Featureid = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                        Unit_Measurementid = c.Int(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Product_Feature", "Unit_Measurementid");
            CreateIndex("dbo.Product_Feature", "Featureid");
            CreateIndex("dbo.Product_Feature", "Productid");
            AddForeignKey("dbo.Product_Feature", "Unit_Measurementid", "dbo.Unit_Measurement", "id");
            AddForeignKey("dbo.Product_Feature", "Productid", "dbo.Products", "id", cascadeDelete: true);
            AddForeignKey("dbo.Product_Feature", "Featureid", "dbo.Features", "id", cascadeDelete: true);
        }
    }
}
