namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Location_type : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_type = c.Int(),
                        code = c.String(),
                        name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Location_Type");
        }
    }
}
