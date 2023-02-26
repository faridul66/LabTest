namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesOrderExts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Lot = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalesOrderExts");
        }
    }
}
