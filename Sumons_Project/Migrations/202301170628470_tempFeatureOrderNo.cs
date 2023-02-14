namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempFeatureOrderNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Temp_Feature", "OrderNo", c => c.String());
            DropColumn("dbo.Temp_Feature", "Orderid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Temp_Feature", "Orderid", c => c.String());
            DropColumn("dbo.Temp_Feature", "OrderNo");
        }
    }
}
