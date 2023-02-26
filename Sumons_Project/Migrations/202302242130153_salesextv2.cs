namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesextv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesOrderExts", "ProductTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.SalesOrderExts", "UnitId", c => c.Int(nullable: false));
            AddColumn("dbo.SalesOrderExts", "SiteId", c => c.Int(nullable: false));
            AddColumn("dbo.SalesOrderExts", "WarehouseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalesOrderExts", "WarehouseId");
            DropColumn("dbo.SalesOrderExts", "SiteId");
            DropColumn("dbo.SalesOrderExts", "UnitId");
            DropColumn("dbo.SalesOrderExts", "ProductTypeId");
        }
    }
}
