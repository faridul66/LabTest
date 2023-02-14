namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product_Type", "parent_type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product_Type", "parent_type", c => c.Int(nullable: false));
        }
    }
}
