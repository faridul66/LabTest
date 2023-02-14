namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherType2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Other_Consumption_Ledger", "Other_Consumptionid", c => c.Int(nullable: false));
            AddColumn("dbo.Other_Consumption_Ledger", "Locationid", c => c.Int(nullable: false));
            CreateIndex("dbo.Other_Consumption_Ledger", "Other_Consumptionid");
            CreateIndex("dbo.Other_Consumption_Ledger", "Locationid");
            AddForeignKey("dbo.Other_Consumption_Ledger", "Locationid", "dbo.Locations", "id", cascadeDelete: true);
            AddForeignKey("dbo.Other_Consumption_Ledger", "Other_Consumptionid", "dbo.Other_Consumption", "id", cascadeDelete: true);
            DropColumn("dbo.Other_Consumption_Ledger", "other_consumption_id");
            DropColumn("dbo.Other_Consumption_Ledger", "from_warehouse_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Other_Consumption_Ledger", "from_warehouse_id", c => c.Int(nullable: false));
            AddColumn("dbo.Other_Consumption_Ledger", "other_consumption_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Other_Consumption_Ledger", "Other_Consumptionid", "dbo.Other_Consumption");
            DropForeignKey("dbo.Other_Consumption_Ledger", "Locationid", "dbo.Locations");
            DropIndex("dbo.Other_Consumption_Ledger", new[] { "Locationid" });
            DropIndex("dbo.Other_Consumption_Ledger", new[] { "Other_Consumptionid" });
            DropColumn("dbo.Other_Consumption_Ledger", "Locationid");
            DropColumn("dbo.Other_Consumption_Ledger", "Other_Consumptionid");
        }
    }
}
