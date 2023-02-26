namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderIdint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrderProductFeatures", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesOrderProductFeatures", "OrderId", c => c.String());
        }
    }
}
