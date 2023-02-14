namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featureUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Unit_Measurement", "parent_sum", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Unit_Measurement", "parent_sum", c => c.Int(nullable: false));
        }
    }
}
