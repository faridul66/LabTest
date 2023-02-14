namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransferLedgerUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transfer_Ledger", "Transfer_Orderid", c => c.Int(nullable: false));
            AddColumn("dbo.Transfer_Ledger", "Locationid", c => c.Int(nullable: false));
            CreateIndex("dbo.Transfer_Ledger", "Transfer_Orderid");
            CreateIndex("dbo.Transfer_Ledger", "Locationid");
            AddForeignKey("dbo.Transfer_Ledger", "Locationid", "dbo.Locations", "id", cascadeDelete: true);
            AddForeignKey("dbo.Transfer_Ledger", "Transfer_Orderid", "dbo.Transfer_Order", "id", cascadeDelete: true);
            DropColumn("dbo.Transfer_Ledger", "transfer_order_id");
            DropColumn("dbo.Transfer_Ledger", "to_warehouse_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transfer_Ledger", "to_warehouse_id", c => c.Int(nullable: false));
            AddColumn("dbo.Transfer_Ledger", "transfer_order_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transfer_Ledger", "Transfer_Orderid", "dbo.Transfer_Order");
            DropForeignKey("dbo.Transfer_Ledger", "Locationid", "dbo.Locations");
            DropIndex("dbo.Transfer_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Transfer_Ledger", new[] { "Transfer_Orderid" });
            DropColumn("dbo.Transfer_Ledger", "Locationid");
            DropColumn("dbo.Transfer_Ledger", "Transfer_Orderid");
        }
    }
}
