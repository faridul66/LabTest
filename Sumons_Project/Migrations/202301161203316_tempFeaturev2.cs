namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempFeaturev2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Temp_Feature", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Temp_Feature", "CompanyId");
            AddForeignKey("dbo.Temp_Feature", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Temp_Feature", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Temp_Feature", new[] { "CompanyId" });
            DropColumn("dbo.Temp_Feature", "CompanyId");
        }
    }
}
