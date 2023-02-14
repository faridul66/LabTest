namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class machineupd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machine_Type", "chgd_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Machine_Product", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Machine_Type", "chged_datetime");
            DropColumn("dbo.Machine_Product", "name");
            DropColumn("dbo.Machine_Product", "chged_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machine_Product", "chged_datetime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Machine_Product", "name", c => c.String());
            AddColumn("dbo.Machine_Type", "chged_datetime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Machine_Product", "chgd_date");
            DropColumn("dbo.Machine_Type", "chgd_date");
        }
    }
}
