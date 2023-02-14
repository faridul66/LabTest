namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class machineupd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Machines", "chged_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machines", "chged_datetime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Machines", "chgd_date");
        }
    }
}
