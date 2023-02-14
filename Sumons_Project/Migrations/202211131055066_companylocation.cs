namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companylocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company_Location",
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
            DropForeignKey("dbo.Company_Location", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Company_Location", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Company_Location", new[] { "Locationid" });
            DropIndex("dbo.Company_Location", new[] { "CompanyId" });
            DropTable("dbo.Company_Location");
        }
    }
}
