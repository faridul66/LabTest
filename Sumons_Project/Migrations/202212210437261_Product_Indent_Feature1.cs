namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Indent_Feature1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product_Indent_Feature", "FeatureValue", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product_Indent_Feature", "FeatureValue", c => c.Double(nullable: false));
        }
    }
}
