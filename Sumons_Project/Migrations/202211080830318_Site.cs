namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Site : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Int_CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Int_Company", t => t.Int_CompanyID, cascadeDelete: true)
                .Index(t => t.Int_CompanyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "Int_CompanyID", "dbo.Int_Company");
            DropIndex("dbo.Sites", new[] { "Int_CompanyID" });
            DropTable("dbo.Sites");
        }
    }
}
