namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class tempFeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Temp_Feature",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Transaction_Typeid = c.Int(nullable: false),
                    Orderid = c.Int(),
                    Lot = c.Int(),
                    Featureid = c.Int(),
                    Feature_Typeid = c.Int(),
                    FeatureValue = c.Double(),
                    Unit_Measurementid = c.Int(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid)
                .ForeignKey("dbo.Feature_Type", t => t.Feature_Typeid)
                .ForeignKey("dbo.Transaction_Type", t => t.Transaction_Typeid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid)
                .Index(t => t.Transaction_Typeid)
                .Index(t => t.Featureid)
                .Index(t => t.Feature_Typeid)
                .Index(t => t.Unit_Measurementid);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Temp_Feature", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Temp_Feature", "Transaction_Typeid", "dbo.Transaction_Type");
            DropForeignKey("dbo.Temp_Feature", "Feature_Typeid", "dbo.Feature_Type");
            DropForeignKey("dbo.Temp_Feature", "Featureid", "dbo.Features");
            DropIndex("dbo.Temp_Feature", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Temp_Feature", new[] { "Feature_Typeid" });
            DropIndex("dbo.Temp_Feature", new[] { "Featureid" });
            DropIndex("dbo.Temp_Feature", new[] { "Transaction_Typeid" });
            DropTable("dbo.Temp_Feature");
        }
    }
}
