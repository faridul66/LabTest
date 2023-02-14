namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempFeaturev1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Temp_Feature", "Orderid", c => c.String());
            AlterColumn("dbo.Temp_Feature", "Lot", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Temp_Feature", "Lot", c => c.Int());
            AlterColumn("dbo.Temp_Feature", "Orderid", c => c.Int());
        }
    }
}
