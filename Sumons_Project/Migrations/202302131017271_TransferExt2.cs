namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransferExt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransferOrderExts", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransferOrderExts", "OrderId");
        }
    }
}
