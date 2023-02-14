namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseorderlcdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchase_Order", "lc_date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchase_Order", "lc_date", c => c.DateTime(nullable: false));
        }
    }
}
