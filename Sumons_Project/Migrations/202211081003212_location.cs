namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_location = c.Int(nullable: false),
                        Location_Typeid = c.Int(nullable: false),
                        name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Location_Type", t => t.Location_Typeid, cascadeDelete: true)
                .Index(t => t.Location_Typeid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "Location_Typeid", "dbo.Location_Type");
            DropIndex("dbo.Locations", new[] { "Location_Typeid" });
            DropTable("dbo.Locations");
        }
    }
}
