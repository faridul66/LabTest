namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Indent_Feature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Indent_Feature", "FeatureValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product_Indent_Feature", "FeatureValue");
        }
    }
}
