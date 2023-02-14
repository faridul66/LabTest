namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_code = c.String(),
                        type_name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chged_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transaction_Type");
        }
    }
}
