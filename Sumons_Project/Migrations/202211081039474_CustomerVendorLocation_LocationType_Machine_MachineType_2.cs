namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerVendorLocation_LocationType_Machine_MachineType_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        name = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        address = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Machine_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Companyid = c.Int(nullable: false),
                        Locationid = c.Int(nullable: false),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Companies", t => t.Companyid, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Locationid, cascadeDelete: true)
                .Index(t => t.Companyid)
                .Index(t => t.Locationid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Machines", "Locationid", "dbo.Locations");
            DropForeignKey("dbo.Machines", "Companyid", "dbo.Companies");
            DropIndex("dbo.Machines", new[] { "Locationid" });
            DropIndex("dbo.Machines", new[] { "Companyid" });
            DropTable("dbo.Machines");
            DropTable("dbo.Machine_Type");
            DropTable("dbo.Customers");
        }
    }
}
