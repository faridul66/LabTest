namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cstupd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "chged_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "chged_datetime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "chgd_date");
        }
    }
}
