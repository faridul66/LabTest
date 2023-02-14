namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returnOrder_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Return_Order", "return_value", c => c.Double(nullable: false));
            AlterColumn("dbo.Return_Order", "qty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Return_Order", "qty", c => c.Double(nullable: false));
            DropColumn("dbo.Return_Order", "return_value");
        }
    }
}
