namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyIDlocationID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyID_LocationID",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        status = c.String(),
                        Chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.Locationid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyID_LocationID", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.CompanyID_LocationID", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompanyID_LocationID", new[] { "Locationid" });
            DropIndex("dbo.CompanyID_LocationID", new[] { "CompanyId" });
            DropTable("dbo.CompanyID_LocationID");
        }
    }
}
