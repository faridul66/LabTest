namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locupd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Locations", "chged_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "chged_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Locations", "chgd_date");
        }
    }
}
