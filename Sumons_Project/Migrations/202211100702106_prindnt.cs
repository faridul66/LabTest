namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prindnt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Production_Indent", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Production_Indent", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
