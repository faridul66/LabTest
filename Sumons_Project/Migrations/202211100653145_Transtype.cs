namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction_Type", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction_Type", "chged_datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction_Type", "chged_datetime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction_Type", "chgd_date");
        }
    }
}
