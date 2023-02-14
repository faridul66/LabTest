namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "status", c => c.String());
            AddColumn("dbo.Companies", "chgd_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Companies", "Chged_DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Chged_DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Companies", "chgd_date");
            DropColumn("dbo.Companies", "status");
        }
    }
}
