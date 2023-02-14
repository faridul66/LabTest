namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feature_Unitmeasurement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feature_UnitMeasurement",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Featureid = c.Int(nullable: false),
                        Unit_Measurementid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Unit_Measurement", t => t.Unit_Measurementid, cascadeDelete: false)
                .Index(t => t.Featureid)
                .Index(t => t.Unit_Measurementid);
        }
        public override void Down()
        {
            DropForeignKey("dbo.Feature_UnitMeasurement", "Unit_Measurementid", "dbo.Unit_Measurement");
            DropForeignKey("dbo.Feature_UnitMeasurement", "Featureid", "dbo.Features");
            DropIndex("dbo.Feature_UnitMeasurement", new[] { "Unit_Measurementid" });
            DropIndex("dbo.Feature_UnitMeasurement", new[] { "Featureid" });
            DropTable("dbo.Feature_UnitMeasurement");
        }
    }
}
