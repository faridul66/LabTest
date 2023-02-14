namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class featureproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Feature", "Value", c => c.Double(nullable: false));
            DropColumn("dbo.Product_Feature", "Double");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product_Feature", "Double", c => c.String());
            DropColumn("dbo.Product_Feature", "Value");
        }
    }
}
