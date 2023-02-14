namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales_ledger_u1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales_Ledger", "lot_number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales_Ledger", "lot_number");
        }
    }
}
