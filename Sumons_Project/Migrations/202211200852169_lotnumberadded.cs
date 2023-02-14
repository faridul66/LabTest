namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lotnumberadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase_Ledger", "lot_number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase_Ledger", "lot_number");
        }
    }
}
